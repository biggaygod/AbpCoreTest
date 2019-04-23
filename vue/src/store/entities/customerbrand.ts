import Entity from './entity'
export default class CustomerBrand extends Entity<number>
{
    CustomerId?:number;
    CustomerName:string;
    BrandId?:number;
    BrandName:string;
}