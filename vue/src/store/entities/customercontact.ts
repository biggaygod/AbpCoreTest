import Entity from './entity'
export default class CustomerContact extends Entity<number>
{
    CountryCode?:string;
    CountryName:string;
    CustomerId?:number;
    CustomerName:string;
    ContactName:string;
    Address:string;
    Position:string;
    TelePhone:string;
    Email:string;
}