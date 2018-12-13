import Vue from 'vue';
import Vuex from 'vuex';
Vue.use(Vuex);
import app from './modules/app'
import session from './modules/session'
import account from './modules/account'
import user from './modules/user'
import role from './modules/role'
import tenant from './modules/tenant'
import brand from './modules/brand'
import country from './modules/country'
import customer from './modules/customer'
import customerbrand from './modules/customerbrand'
import customerfile from './modules/customerfile'
import customercontact from './modules/customercontact'
const store = new Vuex.Store({
    state: {
        //
    },
    mutations: {
        //
    },
    actions: {

    },
    modules: {
        app,
        session,
        account,
        user,
        role,
        tenant,
        brand,
        country,
        customer,
        customerbrand,
        customerfile,
        customercontact
    }
});

export default store;