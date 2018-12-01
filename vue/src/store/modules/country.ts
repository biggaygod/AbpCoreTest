import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Country from '../entities/country'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import ListMutations from './list-mutations'

interface CountryState extends ListState<Country>{
    editCountry:Country
}
class CountryMutations extends ListMutations<Country>{

}
class CountryModule extends ListModule<CountryState,any,Country>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<Country>(),
        loading:false,
        editCountry:new Country(),
    }
    actions={
        async getAll(context:ActionContext<CountryState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/Country/GetAll',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<Country>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async create(context:ActionContext<CountryState,any>,payload:any){
            await Ajax.post('/api/services/app/Country/Create',payload.data);
        },
        async update(context:ActionContext<CountryState,any>,payload:any){
            await Ajax.put('/api/services/app/Country/Update',payload.data);
        },
        async delete(context:ActionContext<CountryState,any>,payload:any){
            await Ajax.delete('/api/services/app/Country/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<CountryState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/Country/Get?Id='+payload.id);
            return reponse.data.result as Country;
        }
    };
    mutations={
        setCurrentPage(state:CountryState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:CountryState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:CountryState,Country:Country){
            state.editCountry=Country;
        }
    }
}
const countryModule=new CountryModule();
export default countryModule;