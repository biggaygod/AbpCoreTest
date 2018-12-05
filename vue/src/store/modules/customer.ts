import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Customer from '../entities/customer'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import ListMutations from './list-mutations'

interface CustomerState extends ListState<Customer>{
    editCustomer:Customer
}
class CustomerMutations extends ListMutations<Customer>{

}
class CustomerModule extends ListModule<CustomerState,any,Customer>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<Customer>(),
        loading:false,
        editCustomer:new Customer(),
    }
    actions={
        async getAll(context:ActionContext<CustomerState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/customer/GetAll',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<Customer>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async create(context:ActionContext<CustomerState,any>,payload:any){
            await Ajax.post('/api/services/app/customer/Create',payload.data);
        },
        async update(context:ActionContext<CustomerState,any>,payload:any){
            await Ajax.put('/api/services/app/customer/Update',payload.data);
        },
        async delete(context:ActionContext<CustomerState,any>,payload:any){
            await Ajax.delete('/api/services/app/customer/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<CustomerState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/customer/Get?Id='+payload.id);
            return reponse.data.result as Customer;
        }
    };
    mutations={
        setCurrentPage(state:CustomerState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:CustomerState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:CustomerState,Customer:Customer){
            state.editCustomer=Customer;
        }
    }
}
const customerModule=new CustomerModule();
export default customerModule;