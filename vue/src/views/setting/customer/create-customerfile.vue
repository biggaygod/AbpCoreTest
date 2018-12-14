<template>
  <div>
    <Modal
      :title="L('CreateNewfileCustomer')"
      :value="value"
      @on-ok="save"
      @on-visible-change="visibleChange"
    >
      <Form
        ref="customerfileForm"
        label-position="top"
        :model="customerfile"
      >
        <Tabs value="detail">
          <TabPane :label="L('UserDetails')" name="detail">
            <FormItem :label="L('CreateNewFileCustomer')" prop="fileId">
                <Upload
                    action=""
                    multiple
                    :before-upload="handleUpload"
                    >
                    <Button icon="ios-cloud-upload-outline">{{L('UploadFiles')}}</Button>
                </Upload> 
                  <div v-for="(item,index) in files">Upload file: {{ item.name }} <Button type="text" @click="deleteFile(index)">{{L("Delete")}}</Button></div>                    
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
import CustomerFile from "../../../store/entities/customerfile";
@Component({
  components: {}
})
export default class CreateCustomerfile extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  customerfile: CustomerFile = new CustomerFile();
  files: Array<any>=[];
  save() {
    (this.$refs.customerfileForm as any).validate(async (valid: boolean) => {
      if (valid) {
        let formData=new FormData();
        formData.append("CustomerId",Util.extend(true,{},this.$store.state.customer.editCustomer).id);
        this.files.forEach((item,index)=>{
          formData.append("uploadfile",item);
        });
        await this.$store.dispatch({
          type: "customerfile/create",
          data: formData
        });
        (this.$refs.customerfileForm as any).resetFields();
        this.$emit("save-success");
        this.cancel();
      }
    });
  }
  cancel() {
    (this.$refs.customerfileForm as any).resetFields();
    this.$emit("input", false);
  }
  visibleChange(value: boolean) {
    if (!value) {
      this.$emit("input", value);
    }
  }

  //上传前获取
  handleUpload(file)
  {
    this.files.push(file);
  }
  //删除文件
  deleteFile(index:number)
  {
    if(this.files.length>0)
    {
      this.files.splice(index,1);
    }   
  }
}
</script>