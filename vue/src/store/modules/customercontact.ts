import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import CustomerContact from '../entities/customercontact'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import ListMutations from './list-mutations'

interface CustomerContactState extends ListState<CustomerContact>{
    editCustomerContact:CustomerContact
}
class CustomerContactMutations extends ListMutations<CustomerContact>{

}
class CustomerContactModule extends ListModule<CustomerContactState,any,CustomerContact>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<CustomerContact>(),
        loading:false,
        editCustomerContact:new CustomerContact(),
    }
    actions={
        async getAll(context:ActionContext<CustomerContactState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/CustomerContact/GetAll',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<CustomerContact>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async create(context:ActionContext<CustomerContactState,any>,payload:any){
            await Ajax.post('/api/services/app/CustomerContact/Create',payload.data);
        },
        async update(context:ActionContext<CustomerContactState,any>,payload:any){
            await Ajax.put('/api/services/app/CustomerContact/Update',payload.data);
        },
        async delete(context:ActionContext<CustomerContactState,any>,payload:any){
            await Ajax.delete('/api/services/app/CustomerContact/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<CustomerContactState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/CustomerContact/Get?Id='+payload.id);
            return reponse.data.result as CustomerContact;
        }
    };
    mutations={
        setCurrentPage(state:CustomerContactState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:CustomerContactState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:CustomerContactState,CustomerContact:CustomerContact){
            state.editCustomerContact=CustomerContact;
        }
    }
}
const customerContactModule=new CustomerContactModule();
export default customerContactModule;