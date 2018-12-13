<template>
  <div>
    <Modal
      :title="L('CreateNewBrandCustomer')"
      :value="value"
      @on-ok="save"
      @on-visible-change="visibleChange"
    >
      <Form
        ref="customerBrandForm"
        label-position="top"
        :rules="customerBrandRule"
        :model="customerBrand"
      >
        <Tabs value="detail">
          <TabPane :label="L('UserDetails')" name="detail">
            <FormItem :label="L('BrandName')" prop="brandName">
              <brandlist v-model="customerBrand.brandId"></brandlist>
            </FormItem>
            <FormItem :label="L('CreateNewFileCustomer')" prop="brandId">
                <Upload
                    multiple
                    action="//jsonplaceholder.typicode.com/posts/">
                    <Button icon="ios-cloud-upload-outline">{{L('UploadFiles')}}</Button>
                </Upload>
            </FormItem>  
          </TabPane>
        </Tabs>
      </Form>
      <div slot="footer">
        <Button @click="cancel">{{L('Cancel')}}</Button>
        <Button @click="save" type="primary">{{L('OK')}}</Button>
      </div>
    </Modal>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../../lib/util";
import AbpBase from "../../../lib/abpbase";
import CustomerBrand from "../../../store/entities/customerbrand";
import brandlist from "../../../components/brand-list.vue";
@Component({
  components: { brandlist }
})
export default class CreateCustomerBrand extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  customerBrand: CustomerBrand = new CustomerBrand();
  save() {
    (this.$refs.customerBrandForm as any).validate(async (valid: boolean) => {
      if (valid) {
        this.customerBrand.CustomerId = Util.extend(
          true,
          {},
          this.$store.state.customer.editCustomer
        ).id;
        await this.$store.dispatch({
          type: "customerbrand/create",
          data: this.customerBrand
        });
        (this.$refs.customerBrandForm as any).resetFields();
        this.$emit("save-success");
        this.cancel();
      }
    });
  }
  cancel() {
    (this.$refs.customerBrandForm as any).resetFields();
    this.$emit("input", false);
  }
  visibleChange(value: boolean) {
    if (!value) {
      this.$emit("input", value);
    }
  }
  //客户ID查重
  BrandCheck = (rule: any, value: number, callback: any) => {
    let result: boolean = true;
    this.$store.state.customerbrand.list.forEach(u => {
      if (u.brandId === value) {
        result = false;
      }
    });
    if (value === undefined) {
      callback(new Error(this.L("FieldIsRequired")));
    } else if (!result) {
      callback(new Error(this.L("ConfirmBrandRepeat")));
    } else {
      callback();
    }
  };

  customerBrandRule = {
    brandId: [
      {
        required: true,
        trigger: "blur",
        validator: this.BrandCheck
      }
    ]
  };
}
</script>