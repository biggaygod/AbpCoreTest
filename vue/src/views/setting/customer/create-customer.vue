<template>
  <div>
    <Modal
      :title="L('CreateNewCustomer')"
      :value="value"
      @on-ok="save"
      @on-visible-change="visibleChange"
    >
      <Form ref="customerForm" label-position="top" :rules="customerRule" :model="customer">
        <Tabs value="detail">
          <TabPane :label="L('UserDetails')" name="detail">
            <FormItem :label="L('CountryName')" prop="countryName">
              <countrylist v-model="customer.countryCode"></countrylist>
            </FormItem>
            <FormItem :label="L('CountryCode')" prop="countryCode">
              <Input v-model="customer.countryCode" :maxlength="32" :minlength="2" readonly></Input>
            </FormItem>
            <FormItem :label="L('CustomerCode')" prop="customerCode">
              <Input v-model="customer.customerCode" :maxlength="20" :minlength="2"></Input>
            </FormItem>
            <FormItem :label="L('CustomerName')" prop="customerName">
              <Input v-model="customer.customerName" :maxlength="120" :minlength="2"></Input>
            </FormItem>
            <FormItem :label="L('Address')" prop="address">
              <Input v-model="customer.address" :maxlength="2000" :minlength="2"></Input>
            </FormItem>
            <FormItem :label="L('Phone')" prop="phone">
              <Input v-model="customer.phone" :maxlength="120" :minlength="2"></Input>
            </FormItem>
            <FormItem :label="L('SyncId')" prop="syncId">
              <Input v-model="customer.syncId" :maxlength="32"></Input>
            </FormItem>
            <FormItem :label="L('EngName')" prop="engName">
              <Input v-model="customer.engName" :maxlength="1024"></Input>
            </FormItem>
            <FormItem :label="L('Spell')" prop="spell">
              <Input v-model="customer.spell" :maxlength="1024"></Input>
            </FormItem>
            <FormItem>
              <Checkbox v-model="customer.isActive">{{L('IsActive')}}</Checkbox>
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
import Validate from "../../../lib/validate";
import Customer from "../../../store/entities/customer";
import countrylist from "../../../components/country-list.vue";
@Component({
  components: { countrylist }
})
export default class CreateCustomer extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  customer: Customer = new Customer();
  save() {
    (this.$refs.customerForm as any).validate(async (valid: boolean) => {
      if (valid) {
        await this.$store.dispatch({
          type: "customer/create",
          data: this.customer
        });
        (this.$refs.customerForm as any).resetFields();
        this.$emit("save-success");
      }
    });
  }
  cancel() {
    (this.$refs.customerForm as any).resetFields();
    this.$emit("input", false);
  }
  visibleChange(value: boolean) {
    if (!value) {
      this.$emit("input", value);
    }
  }

  customerRule = {
    countryCode: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("CountryCode")),
        trigger: "blur"
      }
    ],
    customerCode: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("CustomerCode")),
        trigger: "blur"
      }
    ],
    customerName: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("CustomerName")),
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
    phone: [{ required: true, validator: Validate.TelCheck, trigger: "blur" }],
    syncId: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("SyncId")),
        trigger: "blur"
      }
    ],
    spell: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("Spell")),
        trigger: "blur"
      }
    ],
    engName: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("EngName")),
        trigger: "blur"
      }
    ]
  };
}
</script>