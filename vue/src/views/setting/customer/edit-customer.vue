<template>
  <div>
    <Modal :title="L('EditUser')" :value="value" @on-ok="save" @on-visible-change="visibleChange">
      <Form ref="CustomerForm" label-position="top" :rules="CustomerRule" :model="Customer">
        <Tabs value="detail">
          <TabPane :label="L('CustomerDetails')" name="detail">
            <FormItem :label="L('CountryCode')" prop="countryCode">
              <Input
                v-model="Customer.countryCode"
                :maxlength="32"
                :minlength="2"
                enable="false"
                disabled
              ></Input>
            </FormItem>
            <FormItem :label="L('CustomerName')" prop="CustomerName">
              <Input v-model="Customer.customerName" :maxlength="32"></Input>
            </FormItem>
            <FormItem :label="L('EngName')" prop="engName">
              <Input v-model="Customer.engName" :maxlength="1024"></Input>
            </FormItem>
            <FormItem :label="L('Spell')" prop="spell">
              <Input v-model="Customer.spell" :maxlength="32"></Input>
            </FormItem>
            <FormItem>
              <Checkbox v-model="Customer.isActive">{{L('IsActive')}}</Checkbox>
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
import Customer from "../../../store/entities/customer";
@Component
export default class EditCustomer extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  Customer: Customer = new Customer();
  created() {}
  save() {
    (this.$refs.CustomerForm as any).validate(async (valid: boolean) => {
      if (valid) {
        await this.$store.dispatch({
          type: "Customer/update",
          data: this.Customer
        });
        (this.$refs.CustomerForm as any).resetFields();
        this.$emit("save-success");
        this.$emit("input", false);
      }
    });
  }
  cancel() {
    (this.$refs.CustomerForm as any).resetFields();
    this.$emit("input", false);
  }
  visibleChange(value: boolean) {
    if (!value) {
      this.$emit("input", value);
    } else {
      this.Customer = Util.extend(true, {}, this.$store.state.customer.editCustomer);
    }
  }
  CustomerRule = {
    countryCode: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("CountryCode")),
        trigger: "blur"
      }
    ],
    CustomerName: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("CustomerName")),
        trigger: "blur"
      }
    ],
    engName: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("EngName")),
        trigger: "blur"
      }
    ],
    spell: [
      {
        required: true,
        message: this.L("FieldIsRequired", undefined, this.L("Spell")),
        trigger: "blur"
      }
    ]
  };
}
</script>
