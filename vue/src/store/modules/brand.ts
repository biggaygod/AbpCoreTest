import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Brand from '../entities/brand'
import Role from '../entities/role'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import ListMutations from './list-mutations'

interface BrandState extends ListState<Brand>{
    editBrand:Brand,
    roles:Role[]
}
class BrandMutations extends ListMutations<Brand>{

}
class BrandModule extends ListModule<BrandState,any,Brand>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<Brand>(),
        loading:false,
        editUser:new Brand(),
        roles:new Array<Role>()
    }
    actions={
        async getAll(context:ActionContext<BrandState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/Brand/GetAllBrand',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<Brand>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async create(context:ActionContext<BrandState,any>,payload:any){
            await Ajax.post('/api/services/app/Brand/CreateBrand',payload.data);
        },
        async update(context:ActionContext<BrandState,any>,payload:any){
            await Ajax.put('/api/services/app/Brand/UpdateBrand',payload.data);
        },
        async delete(context:ActionContext<BrandState,any>,payload:any){
            await Ajax.delete('/api/services/app/Brand/DeleteBrand?Id='+payload.data.id);
        },
        async get(context:ActionContext<BrandState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/Brand/GetBrand?Id='+payload.id);
            return reponse.data.result as Brand;
        },
        async getRoles(context:ActionContext<BrandState,any>){
            let reponse=await Ajax.get('/api/services/app/User/GetRoles');
            context.state.roles=reponse.data.result.items as Role[];
        },
        async changeLanguage(context:ActionContext<BrandState,any>,payload:any){
            await Ajax.post('/api/services/app/User/ChangeLanguage',payload.data);
        }
    };
    mutations={
        setCurrentPage(state:BrandState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:BrandState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:BrandState,Brand:Brand){
            state.editBrand=Brand;
        }
    }
}
const brandModule=new BrandModule();
export default brandModule;