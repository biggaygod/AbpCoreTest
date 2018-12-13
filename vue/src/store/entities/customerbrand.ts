import Entity from './entity'
export default class CustomerBrand extends Entity<number>
{
    CountryCode?:string;
    CountryName:string;
    CustomerId?:number;
    CustomerName:string;
    BrandId?:number;
    BrandName:string;
}