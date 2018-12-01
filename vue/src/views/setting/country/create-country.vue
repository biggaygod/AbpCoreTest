<template>
    <div>
        <Modal
         :title="L('CreateNewCountry')"
         :value="value"
         @on-ok="save"
         @on-visible-change="visibleChange"
        >
            <Form ref="countryForm"  label-position="top" :rules="countryRule" :model="country">
                <Tabs value="detail">
                    <TabPane :label="L('UserDetails')" name="detail">
                        <FormItem :label="L('CountryCode')" prop="countryCode">
                            <Input v-model="country.countryCode" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('CountryName')" prop="countryName">
                            <Input v-model="country.countryName" :maxlength="32"></Input>
                        </FormItem>
                        <FormItem :label="L('CountryShort')" prop="countryShort">
                            <Input v-model="country.countryShort" :maxlength="1024"></Input>
                        </FormItem>
                        <FormItem :label="L('ChineseName')" prop="chineseName">
                            <Input v-model="country.chineseName" :maxlength="1024"></Input>
                        </FormItem>
                        <FormItem :label="L('EnglishName')" prop="englishName">
                            <Input v-model="country.englishName" :maxlength="1024"></Input>
                        </FormItem>
                        <FormItem>
                            <Checkbox v-model="country.isActive">{{L('IsActive')}}</Checkbox>
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
    import Country from '../../../store/entities/country'
    @Component
    export default class CreateBrand extends AbpBase{
        @Prop({type:Boolean,default:false}) value:boolean;
        country:Country=new Country();
        save(){
            (this.$refs.countryForm as any).validate(async (valid:boolean)=>{
                if(valid){
                    await this.$store.dispatch({
                        type:'country/create',
                        data:this.country
                    });
                    (this.$refs.countryForm as any).resetFields();
                    this.$emit('save-success');
                    this.$emit('input',false);
                }
            })
        }
        cancel(){
            (this.$refs.countryForm as any).resetFields();
            this.$emit('input',false);
        }
        visibleChange(value:boolean){
            if(!value){
                this.$emit('input',value);
            }
        }
        countryRule={
            countryCode:[{required:true,message:this.L('FieldIsRequired',undefined,this.L('CountryCode')),trigger: 'blur'}],
            countryName:[{required:true,message:this.L('FieldIsRequired',undefined,this.L('CountryName')),trigger: 'blur'}],
            countryShort:[{required:true,message:this.L('FieldIsRequired',undefined,this.L('CountryShort')),trigger: 'blur'}],
            chineseName:[{required:true,message:this.L('FieldIsRequired',undefined,this.L('ChineseName')),trigger: 'blur'}],
            englishName:[{required:true,message:this.L('FieldIsRequired',undefined,this.L('EnglishName')),trigger: 'blur'}],
        }
    }
</script>

