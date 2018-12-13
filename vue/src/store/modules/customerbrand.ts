import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import CustomerBrand from '../entities/customerbrand'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import ListMutations from './list-mutations'

interface CustomerBrandState extends ListState<CustomerBrand>{
    editCustomerBrand:CustomerBrand
}
class CustomerBrandMutations extends ListMutations<CustomerBrand>{

}
class CustomerBrandModule extends ListModule<CustomerBrandState,any,CustomerBrand>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<CustomerBrand>(),
        loading:false,
        editCustomerBrand:new CustomerBrand(),
    }
    actions={
        async getAll(context:ActionContext<CustomerBrandState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/customerbrand/GetAll',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<CustomerBrand>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async create(context:ActionContext<CustomerBrandState,any>,payload:any){
            await Ajax.post('/api/services/app/customerbrand/Create',payload.data);
        },
        async update(context:ActionContext<CustomerBrandState,any>,payload:any){
            await Ajax.put('/api/services/app/customerbrand/Update',payload.data);
        },
        async delete(context:ActionContext<CustomerBrandState,any>,payload:any){
            await Ajax.delete('/api/services/app/customerbrand/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<CustomerBrandState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/customerbrand/Get?Id='+payload.id);
            return reponse.data.result as CustomerBrand;
        }
    };
    mutations={
        setCurrentPage(state:CustomerBrandState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:CustomerBrandState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:CustomerBrandState,CustomerBrand:CustomerBrand){
            state.editCustomerBrand=CustomerBrand;
        }
    }
}
const customerbrandModule=new CustomerBrandModule();
export default customerbrandModule;