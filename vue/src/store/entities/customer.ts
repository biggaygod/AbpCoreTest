import Entity from './entity'
export default class Customer extends Entity<number>
{
    CountryCode?:string;
    CountryName:string;
    CustomerCode:string;
    CustomerName:string;
    Address:string;
    Phone:string;
    EngName:string;
    Spell:string;
    SyncId?:number;
    IsActive:boolean;
}