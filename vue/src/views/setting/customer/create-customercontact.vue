<template>
  <div>
    <Modal
      :title="L('CreateNewContactCustomer')"
      :value="value"
      @on-ok="save"
      @on-visible-change="visibleChange"
    >
      <Form
        ref="customerContactForm"
        label-position="top"
        :rules="customerContactRule"
        :model="customerContact"
      >
        <Tabs value="detail">
          <TabPane :label="L('UserDetails')" name="detail">
            <FormItem :label="L('ContactName')" prop="contactName">
              <Input v-model="customerContact.contactName" :maxlength="30" :minlength="2"></Input>
            </FormItem>
            <FormItem :label="L('Address')" prop="address">
              <Input v-model="customerContact.address" :maxlength="2000" :minlength="2"></Input>
            </FormItem>
            <FormItem :label="L('Position')" prop="position">
              <Input v-model="customerContact.position" :maxlength="120" :minlength="2"></Input>
            </FormItem>
            <FormItem :label="L('TelePhone')" prop="telePhone">
              <Input v-model="customerContact.telePhone" :maxlength="32" :minlength="2"></Input>
            </FormItem>
            <FormItem :label="L('Email')" prop="email">
              <Input v-model="customerContact.email" :maxlength="32" :minlength="2"></Input>
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
import CustomerContact from "../../../store/entities/customercontact";
import Validate from "../../../lib/validate"
@Component({
})
export default class CreateCustomerContact extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  customerContact: CustomerContact = new CustomerContact();
  save() {
    (this.$refs.customerContactForm as any).validate(async (valid: boolean) => {
      if (valid) {
        this.customerContact.CustomerId = Util.extend(
          true,
          {},
          this.$store.state.customer.editCustomer
        ).id;
        await this.$store.dispatch({
          type: "customercontact/create",
          data: this.customerContact
        });
        (this.$refs.customerContactForm as any).resetFields();
        this.$emit("save-success");
        this.cancel();
      }
    });
  }
  cancel() {
    (this.$refs.customerContactForm as any).resetFields();
    this.$emit("input", false);
  }
  visibleChange(value: boolean) {
    if (!value) {
      this.$emit("input", value);
    }
  }

  customerContactRule = {
    contactName: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("ContactName")),
        trigger: "blur"
      }
    ],
    address: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("Address")),
        trigger: "blur"
      }
    ],
    position: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("Position")),
        trigger: "blur"
      }
    ],
    telePhone: [
      {
        required: true,
        validator:Validate.TelCheck,
        trigger: "blur"
      }
    ],
    email: [
      {
        required: true,
        validator:Validate.EmailCheck,
        trigger: "blur"
      }
    ]
  };
}
</script>