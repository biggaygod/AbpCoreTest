<template>
    <div>
        <i-select v-model="values" :model.sync="values"  filterable>
            <i-option v-for="item in list" :key="item.countryCode" :value="item.countryCode" >{{ item.countryName }}</i-option>
        </i-select>
    </div>  
</template>

<script lang="ts">
import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
import Util from '../lib/util'
import AbpBase from '../lib/abpbase'
import PageRequest from '../store/entities/page-request'
import Country from '../store/entities/country'
@Component
export default class CountryList extends AbpBase{
    @Prop({type:String,default:""}) 
    value:string;
    values=this.value;
    async getCountrys(){
            let where= null;
            let pagerequest=new PageRequest();
            pagerequest.maxResultCount=1000;
            pagerequest.skipCount=0;
            pagerequest.where=where;
            await this.$store.dispatch({
                type:'country/getAll',
                data:pagerequest
            })
    }
    
    get list()
    {
        return this.$store.state.country.list;
    }

    @Watch('value')
    getcode(val:string,oldval:string)
    {
       this.values=val 
    }

    @Watch('values')
    changecode(val:string,oldval:string)
    {
        this.$emit('input', val); // 通过$emit触发父组件  
    }
    created(){
        this.getCountrys();
    }
}
</script>