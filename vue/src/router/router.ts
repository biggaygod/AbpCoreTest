declare global {
    interface System {
      import (request: string): Promise<any>
    }
    var System: System
}
import login from '../views/login.vue'
import home from '../views/home/home.vue'
import main from '../views/main.vue'
export const locking = {
    path: '/locking',
    name: 'locking',
    component: () => import('../components/lockscreen/components/locking-page.vue')
};
export const loginRouter = {
    path: '/',
    name: 'login',
    meta: {
        title: 'LogIn'
    },
    component:()=>import('../views/login.vue')
};
export const otherRouters={
    path:'/main',
    name:'main',
    permission:'',
    meta:{title:'ManageMenu'},
    component:main,
    children:[
        {path: 'home', meta:{title:'HomePage'}, name: 'home', component:()=>import('../views/home/home.vue')}
    ]
}
export const appRouters=[{
    path:'/setting',
    name:'setting',
    permission:'',
    meta:{title:'主菜单'},
    icon:'&#xe68a;',
    component:main,
    children:[
        {path: 'user',permission:'Pages.Users', meta:{title:'Users'}, name: 'user', component:()=>import('../views/setting/user/user.vue')},
        {path: 'role',permission:'Pages.Roles', meta:{title:'Roles'}, name: 'role', component:()=>import('../views/setting/role/role.vue')},
        {path: 'tenant',permission:'Pages.Tenants', meta:{title:'Tenants'}, name: 'tenant', component:()=>import('../views/setting/tenant/tenant.vue')}
    ]
    },{
    path:'/setting',
    name:'baseData',
    permission:'',
    meta:{title:'基础数据'},
    icon:'&#xe68a;',
    component:main,
    children:[
        {path: 'brand',permission:'Pages.Brands', meta:{title:'Brands'}, name: 'brand', component:()=>import('../views/setting/brand/brand.vue')},
        {path: 'country',permission:'Pages.Countrys', meta:{title:'Countrys'}, name: 'country', component:()=>import('../views/setting/country/country.vue')}
    ]},
    {
    path:'/setting',
    name:'customerInfo',
    permission:'',
    meta:{title:'客户信息'},
    icon:'&#xe68a;',
    component:main,
    children:[
        {path: 'customer',permission:'Pages.Customers', meta:{title:'Customers'}, name: 'customer', component:()=>import('../views/setting/customer/customer.vue')}
    ]}
]
export const routers = [
    loginRouter,
    locking,
    ...appRouters,
    otherRouters
];
