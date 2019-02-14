import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import CustomerFile from '../entities/customerfile'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import ListMutations from './list-mutations'

interface CustomerFileState extends ListState<CustomerFile>{
    editCustomerFile:CustomerFile
}
class CustomerFileMutations extends ListMutations<CustomerFile>{

}
class CustomerFileModule extends ListModule<CustomerFileState,any,CustomerFile>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<CustomerFile>(),
        loading:false,
        editCustomerFile:new CustomerFile(),
    }
    actions={
        async getAll(context:ActionContext<CustomerFileState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/CustomerFile/GetAll',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<CustomerFile>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async create(context:ActionContext<CustomerFileState,any>,payload:any){
            await Ajax.post('/api/Files/CreateCustomerFile',payload.data,{ });
        },
        async update(context:ActionContext<CustomerFileState,any>,payload:any){
            await Ajax.put('/api/services/app/CustomerFile/Update',payload.data);
        },
        async delete(context:ActionContext<CustomerFileState,any>,payload:any){
            await Ajax.delete('/api/services/app/CustomerFile/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<CustomerFileState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/CustomerFile/Get?Id='+payload.id);
            return reponse.data.result as CustomerFile;
        },
        async download(context:ActionContext<CustomerFileState,any>,payload:any){
            await Ajax.get('/api/Files/DownLoadCustomerFile?file='+payload.FileName);
        }
    };
    mutations={
        setCurrentPage(state:CustomerFileState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:CustomerFileState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:CustomerFileState,CustomerFile:CustomerFile){
            state.editCustomerFile=CustomerFile;
        }
    }
}
const customerFileModule=new CustomerFileModule();
export default customerFileModule;