<template>
  <div>
    <Modal width="980px" :title="L('CustomerRelation')" :value="value" @on-visible-change="visibleChange">
      <Tabs active-key="key1">
        <Tab-pane :label="L('CustomerBrand')" key="CustomerBrand">
          <Button @click="create(1)" icon="android-add" type="primary" size="large">{{L('Add')}}</Button>
          <div class="margin-top-10">
            <Table
              :loading="loading"
              :columns="columnsbrand"
              :no-data-text="L('NoDatas')"
              border
              :data="listbrand"
            ></Table>
          </div>
          <createcustomerbrand v-model="createBrandModalShow" @save-success="getpage"></createcustomerbrand>
        </Tab-pane>
        <Tab-pane :label="L('CustomerContact')" key="CustomerContact">
          <Button @click="create(2)" icon="android-add" type="primary" size="large">{{L('Add')}}</Button>
          <div class="margin-top-10">
            <Table
              :loading="loading"
              :columns="columnscontact"
              :no-data-text="L('NoDatas')"
              border
              :data="listcontact"
            ></Table>
          </div>
          <createcustomercontact v-model="createContactModalShow" @save-success="getpage"></createcustomercontact>
        </Tab-pane>
        <Tab-pane :label="L('CustomerFile')" key="CustomerFile">
          <Button @click="create(3)" icon="android-add" type="primary" size="large">{{L('Add')}}</Button>
          <div class="margin-top-10">
            <Table
              :loading="loading"
              :columns="columnsfile"
              :no-data-text="L('NoDatas')"
              border
              :data="listfile"
            ></Table>
          </div>
          <createcustomerfile v-model="createFileModalShow" @save-success="getpage"></createcustomerfile>
        </Tab-pane>
      </Tabs>
      <div slot="footer">
        <Button @click="cancel">{{L('Cancel')}}</Button>
      </div>
    </Modal>
  </div>
</template>

<script lang='ts'>
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../../lib/util";
import AbpBase from "../../../lib/abpbase";
import { FieldType, Filter, CompareType } from "../../../store/entities/filter";
import PageRequest from "../../../store/entities/page-request";
import createcustomerbrand from "./create-customerbrand.vue";
import createcustomercontact from "./create-customercontact.vue";
import createcustomerfile from "./create-customerfile.vue";
@Component({
  components:{createcustomerbrand,createcustomercontact,createcustomerfile}
})
export default class RelativeCustomer extends AbpBase {
  //关联品牌操作状态
  createBrandModalShow: boolean = false;
  editBrandModalShow: boolean = false;
  //关联联系方式操作状态
  createContactModalShow: boolean = false;
  editContactModalShow: boolean = false;
  //关联文件操作状态
  createFileModalShow: boolean = false;
  editFileModalShow: boolean = false;

    //新建关联文件
  create(type: number) {
    switch (type) {
      case 1:this.createBrandModalShow=true;
        break;
      case 2:this.createContactModalShow=true;
        break;
      case 3:this.createFileModalShow=true;
        break;
    }
  }
  //编辑关联文件
  edit(type: number) {
    switch (type) {
      case 1:this.editBrandModalShow=true;
        break;
      case 2:this.editContactModalShow=true;
        break;
      case 3:this.editFileModalShow=true;
        break;
    }
  }

  @Prop({ type: Boolean, default: false }) value: boolean;

  filters:Filter[];
  setFilter(){
  this.filters = [
    {
      Type: FieldType.String,
      Value: Util.extend(true, {}, this.$store.state.customer.editCustomer).id,
      FieldName: "CustomerId",
      CompareType: CompareType.Equal
    }
    ];
  }

  cancel() {
    this.$emit("input", false);
  }
  visibleChange(value: boolean) {
    if (!value) {
      this.$emit("input", value);
    }
    else{
      this.getpage();
    }
  }
  //关联数据数据源
  get listbrand() {
    return this.$store.state.customerbrand.list;
  }
  get listcontact() {
    return this.$store.state.customercontact.list;
  }
  get listfile() {
    return this.$store.state.customerfile.list;
  }

  get loading() {
    return this.$store.state.customer.loading;
  }
  async getpage() {
    this.setFilter(); 
    let where = Util.buildFilters(this.filters);
    let pagerequest = new PageRequest();
    pagerequest.maxResultCount = 1000000;
    pagerequest.skipCount = 0;
    pagerequest.where = where;
    //获取关联品牌列表
    await this.$store.dispatch({
      type: "customerbrand/getAll",
      data: pagerequest
    });
    //获取关联联系方式列表
    await this.$store.dispatch({
      type: "customercontact/getAll",
      data: pagerequest
    });
    //获取关联文件列表
    await this.$store.dispatch({
      type: "customerfile/getAll",
      data: pagerequest
    });
  }

  //关联品牌数据绑定
  columnsbrand = [
    {
      title: this.L("CustomerId"),
      key: "customerId"
    },
    {
      title: this.L("CustomerName"),
      key: "customerName"
    },
    {
      title: this.L("BrandId"),
      key: "brandId"
    },{
      title: this.L("BrandName"),
      key: "brandname"
    },
    {
      title: this.L("Actions"),
      key: "Actions",
      width: 150,
      render: (h: any, params: any) => {
        return h("div", [
          h(
            "Button",
            {
              props: {
                type: "primary",
                size: "small"
              },
              style: {
                marginRight: "5px"
              },
              on: {
                click: () => {
                  this.$store.commit("customerbrand/edit", params.row);
                  this.edit(1);
                }
              }
            },
            this.L("Edit")
          ),
          h(
            "Button",
            {
              props: {
                type: "error",
                size: "small"
              },
              on: {
                click: async () => {
                  this.$Modal.confirm({
                    title: this.L("Tips"),
                    content: this.L("DeleteUserConfirm"),
                    okText: this.L("Yes"),
                    cancelText: this.L("No"),
                    onOk: async () => {
                      await this.$store.dispatch({
                        type: "customerbrand/delete",
                        data: params.row
                      });
                      await this.getpage();
                    }
                  });
                }
              }
            },
            this.L("Delete")
          )
        ]);
      }
    }
  ];
  //关联联系方式数据绑定
  columnscontact = [
    {
      title: this.L("CustomerId"),
      key: "customerId"
    },
    {
      title: this.L("CustomerName"),
      key: "customerName"
    },
    {
      title: this.L("ContactName"),
      key: "contactName"
    },
    {
      title: this.L("Address"),
      key: "address"
    },{
      title: this.L("Position"),
      key: "position"
    },{
      title: this.L("TelePhone"),
      key: "telePhone"
    },{
      title: this.L("Email"),
      key: "email"
    },
    {
      title: this.L("Actions"),
      key: "Actions",
      width: 150,
      render: (h: any, params: any) => {
        return h("div", [
          h(
            "Button",
            {
              props: {
                type: "primary",
                size: "small"
              },
              style: {
                marginRight: "5px"
              },
              on: {
                click: () => {
                  this.$store.commit("customercontact/edit", params.row);
                  this.edit(2);
                }
              }
            },
            this.L("Edit")
          ),
          h(
            "Button",
            {
              props: {
                type: "error",
                size: "small"
              },
              on: {
                click: async () => {
                  this.$Modal.confirm({
                    title: this.L("Tips"),
                    content: this.L("DeleteUserConfirm"),
                    okText: this.L("Yes"),
                    cancelText: this.L("No"),
                    onOk: async () => {
                      await this.$store.dispatch({
                        type: "customercontact/delete",
                        data: params.row
                      });
                      await this.getpage();
                    }
                  });
                }
              }
            },
            this.L("Delete")
          )
        ]);
      }
    }
  ];;
  //关联文件数据绑定
  columnsfile = [
    {
      title: this.L("CustomerId"),
      key: "customerId"
    },
    {
      title: this.L("CustomerName"),
      key: "customerName"
    },
    {
      title: this.L("FilePath"),
      key: "filePath"
    },{
      title: this.L("FileName"),
      key: "fileName"
    },
    {
      title: this.L("Actions"),
      key: "Actions",
      width: 150,
      render: (h: any, params: any) => {
        return h("div", [
          h(
            "Button",
            {
              props: {
                type: "primary",
                size: "small"
              },
              style: {
                marginRight: "5px"
              },
              on: {
                click: async () => {
                  await this.$store.dispatch( {type:"customerfile/view", data:params.row});
                }
              }
            },
            this.L("View")
          ),
          h(
            "Button",
            {
              props: {
                type: "error",
                size: "small"
              },
              on: {
                click: async () => {
                  this.$Modal.confirm({
                    title: this.L("Tips"),
                    content: this.L("DeleteUserConfirm"),
                    okText: this.L("Yes"),
                    cancelText: this.L("No"),
                    onOk: async () => {
                      await this.$store.dispatch({
                        type: "customerfile/delete",
                        data: params.row
                      });
                      await this.getpage();
                    }
                  });
                }
              }
            },
            this.L("Delete")
          )
        ]);
      }
    }
  ];
  created() {
    
  }
}
</script>