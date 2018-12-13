import Entity from './entity'
export default class CustomerFile extends Entity<number>
{
    CountryCode?:string;
    CountryName:string;
    CustomerId?:number;
    CustomerName:string;
    FilePath:string;
    FileName:string;
}