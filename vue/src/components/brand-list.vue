<template>
    <div>
        <i-select v-model="values" :model.sync="values"  filterable>
            <i-option v-for="item in list" :key="item.id" :value="item.id" >{{ item.brandName }}</i-option>
        </i-select>
    </div>  
</template>
<script lang="ts">
import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
import Util from '../lib/util'
import AbpBase from '../lib/abpbase'
import PageRequest from '../store/entities/page-request'
import Brand from '../store/entities/brand'
@Component
export default class BrandList extends AbpBase {
    @Prop({type:Number,default:null}) 
    value:number;
    values=this.value;
    async getBrands(){
            let where= null;
            let pagerequest=new PageRequest();
            pagerequest.maxResultCount=1000;
            pagerequest.skipCount=0;
            pagerequest.where=where;
            await this.$store.dispatch({
                type:'brand/getAll',
                data:pagerequest
            })
    }
    
    get list()
    {
        return this.$store.state.brand.list;
    }

    @Watch('value')
    getcode(val:number,oldval:string)
    {
       this.values=val 
    }

    @Watch('values') 
    changecode(val:number,oldval:string)
    {
        this.$emit('input', val); // 通过$emit触发父组件  
    }
    created(){
        this.getBrands();
    }
}
</script>
