<template>
    <div>
        <Modal
         :title="L('EditUser')"
         :value="value"
         @on-ok="save"
         @on-visible-change="visibleChange"
        >
            <Form ref="brandForm"  label-position="top" :rules="brandRule" :model="brand">
                <Tabs value="detail">
                    <TabPane :label="L('BrandDetails')" name="detail">
                        <FormItem :label="L('CountryCode')" prop="countryCode">
                            <Input v-model="brand.countryCode" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('BrandName')" prop="brandName">
                            <Input v-model="brand.brandName" :maxlength="32"></Input>
                        </FormItem>
                        <FormItem :label="L('EngName')" prop="engName">
                            <Input v-model="brand.engName" :maxlength="1024"></Input>
                        </FormItem>
                        <FormItem :label="L('Spell')" prop="spell">
                            <Input v-model="brand.spell" :maxlength="32"></Input>
                        </FormItem>
                        <FormItem>
                            <Checkbox v-model="brand.isActive">{{L('IsActive')}}</Checkbox>
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
    import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
    import Util from '../../../lib/util'
    import AbpBase from '../../../lib/abpbase'
    import Brand from '../../../store/entities/brand'
    @Component
    export default class EditBrand extends AbpBase{
        @Prop({type:Boolean,default:false}) value:boolean;
        brand:Brand=new Brand();
        created(){
            
        }
        save(){
            (this.$refs.brandForm as any).validate(async (valid:boolean)=>{
                if(valid){
                    await this.$store.dispatch({
                        type:'brand/update',
                        data:this.brand
                    });
                    (this.$refs.brandForm as any).resetFields();
                    this.$emit('save-success');
                    this.$emit('input',false);
                }
            })
        }
        cancel(){
            (this.$refs.brandForm as any).resetFields();
            this.$emit('input',false);
        }
        visibleChange(value:boolean){
            if(!value){
                this.$emit('input',value);
            }else{
                this.brand=Util.extend(true,{},this.$store.state.brand.editBrand);
            }
        }
        brandRule={
            countryCode:[{required: true,message:this.L('FieldIsRequired',undefined,this.L('CountryCode')),trigger: 'blur'}],
            brandName:[{required:true,message:this.L('FieldIsRequired',undefined,this.L('BrandName')),trigger: 'blur'}],
            engName:[{required:true,message:this.L('FieldIsRequired',undefined,this.L('EngName')),trigger: 'blur'}],
            spell:[{required:true,message:this.L('FieldIsRequired',undefined,this.L('Spell')),trigger: 'blur'}]
        }
    }
</script>

