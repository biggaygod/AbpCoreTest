<template>
    <div>
        <Card dis-hover>
            <div class="page-body">
                <Form ref="queryForm" :label-width="80" label-position="left" inline>
                    <Row :gutter="16">
                        <Col span="6">
                            <FormItem :label="L('CountryCode')+':'" style="width:100%">
                                <Input v-model="filters[0].Value"></Input>
                            </FormItem>
                        </Col>
                        <Col span="6">
                            <FormItem :label="L('CustomerName')+':'" style="width:100%">
                                <Input v-model="filters[1].Value"></Input>
                            </FormItem>
                        </Col>
                        <Col span="6">
                            <FormItem :label="L('IsActive')+':'" style="width:100%">
                                <Select :value="null" :placeholder="L('Select')" @on-change="isActiveChange">
                                    <Option value="All">{{L('All')}}</Option>
                                    <Option value="Actived">{{L('Actived')}}</Option>
                                    <Option value="NoActive">{{L('NoActive')}}</Option>
                                </Select>
                            </FormItem>
                        </Col>
                        <Col span="6">
                            <FormItem :label="L('CreationTime')+':'" style="width:100%">
                                <DatePicker  v-model="filters[2].Value" type="datetimerange" format="yyyy-MM-dd" style="width:100%" placement="bottom-end" :placeholder="L('SelectDate')"></DatePicker>
                            </FormItem>
                        </Col>
                    </Row>
                    <Row>
                        <Button @click="create" icon="android-add" type="primary" size="large">{{L('Add')}}</Button>
                        <Button icon="ios-search" type="primary" size="large" @click="getpage" class="toolbar-btn">{{L('Find')}}</Button>
                    </Row>
                </Form>
                <div class="margin-top-10">
                    <Table :loading="loading" :columns="columns" :no-data-text="L('NoDatas')" border :data="list">
                    </Table>
                    <Page  show-sizer class-name="fengpage" :total="totalCount" class="margin-top-10" @on-change="pageChange" @on-page-size-change="pagesizeChange" :page-size="pageSize" :current="currentPage"></Page>
                </div>
            </div>
        </Card>
        <create-customer v-model="createModalShow" @save-success="getpage"></create-customer>
        <edit-customer v-model="editModalShow" @save-success="getpage"></edit-customer>
    </div>
</template>
<script lang="ts">
    import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
    import Util from '../../../lib/util'
    import AbpBase from '../../../lib/abpbase'
    import {FieldType,Filter,CompareType} from '../../../store/entities/filter'
    import PageRequest from '../../../store/entities/page-request'
    import CreateCustomer from './create-customer.vue'
    import EditCustomer from './edit-customer.vue'
    @Component({
        components:{CreateCustomer,EditCustomer}
    })
    export default class Customers extends AbpBase{
        edit(){
            this.editModalShow=true;
        }
        filters:Filter[]=[
            {Type:FieldType.String,Value:'',FieldName:'CountryCode',CompareType:CompareType.Contains},
            {Type:FieldType.String,Value:'',FieldName:'CustomerName',CompareType:CompareType.Contains},
            {Type:FieldType.DataRange,Value:'',FieldName:'CreationTime',CompareType:CompareType.Contains},
            {Type:FieldType.Boolean,Value:null,FieldName:'IsActive',CompareType:CompareType.Equal}
        ]
        createModalShow:boolean=false;
        editModalShow:boolean=false;
        get list(){
            return this.$store.state.customer.list;
        };
        get loading(){
            return this.$store.state.customer.loading;
        }
        create(){
            this.createModalShow=true;
        }
        isActiveChange(val:string){
            if(val==='Actived'){
                this.filters[3].Value=true;
            }else if(val==='NoActive'){
                this.filters[3].Value=false;
            }else{
                this.filters[3].Value=null;
            }
        }
        pageChange(page:number){
            this.$store.commit('customer/setCurrentPage',page);
            this.getpage();
        }
        pagesizeChange(pagesize:number){
            this.$store.commit('customer/setPageSize',pagesize);
            this.getpage();
        }
        async getpage(){
            let where= Util.buildFilters(this.filters);
            let pagerequest=new PageRequest();
            pagerequest.maxResultCount=this.pageSize;
            pagerequest.skipCount=(this.currentPage-1)*this.pageSize;
            pagerequest.where=where;
            await this.$store.dispatch({
                type:'customer/getAll',
                data:pagerequest
            })
        }
        get pageSize(){
            return this.$store.state.customer.pageSize;
        }
        get totalCount(){
            return this.$store.state.customer.totalCount;
        }
        get currentPage(){
            return this.$store.state.customer.currentPage;
        }
        columns=[{
            title:this.L('CountryCode'),
            key:'countryCode'
        },{
            title:this.L('CountryName'),
            key:'countryName'
        },{
            title:this.L('CustomerCode'),
            key:'customerCode'
        },{
            title:this.L('CustomerName'),
            key:'customerName'
        },{
            title:this.L('Address'),
            key:'address'
        },{
            title:this.L('Phone'),
            key:'phone'
        },{
            title:this.L('EngName'),
            key:'engName'
        },{
            title:this.L('Spell'),
            key:'spell'
        },{
            title:this.L('IsActive'),
            render:(h:any,params:any)=>{
               return h('span',params.row.isActive?this.L('Yes'):this.L('No'))
            }
        },{
            title:this.L('CreatorUserId'),
            key:'creatorUserId'
        },{
            title:this.L('CreationTime'),
            key:'creatioTime',
            render:(h:any,params:any)=>{
                return h('span',new Date(params.row.creationTime).toLocaleDateString())
            }
        },{
            title:this.L('LastModifierUserId'),
            key:'lastModifierUserId'
        },{
            title:this.L('LastModificationTime'),
            key:'lastModificationTime',
            render:(h:any,params:any)=>{
                return h('span',new Date(params.row.lastModificationTime).toLocaleDateString())
            }
        },{
            title:this.L('Actions'),
            key:'Actions',
            width:150,
            render:(h:any,params:any)=>{
                return h('div',[
                    h('Button',{
                        props:{
                            type:'primary',
                            size:'small'
                        },
                        style:{
                            marginRight:'5px'
                        },
                        on:{
                            click:()=>{
                                this.$store.commit('customer/edit',params.row);
                                this.edit();
                            }
                        }
                    },this.L('Edit')),
                    h('Button',{
                        props:{
                            type:'error',
                            size:'small'
                        },
                        on:{
                            click:async ()=>{
                                this.$Modal.confirm({
                                        title:this.L('Tips'),
                                        content:this.L('DeleteUserConfirm'),
                                        okText:this.L('Yes'),
                                        cancelText:this.L('No'),
                                        onOk:async()=>{
                                            await this.$store.dispatch({
                                                type:'customer/delete',
                                                data:params.row
                                            })
                                            await this.getpage();
                                        }
                                })
                            }
                        }
                    },this.L('Delete'))
                ])
            }
        }]
         created(){
            this.getpage();
        }
    }
</script>