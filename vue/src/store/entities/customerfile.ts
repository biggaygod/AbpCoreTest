import Entity from './entity'
export default class CustomerFile extends Entity<number>
{
    CustomerId?:number;
    CustomerName:string;
    FilePath:string;
    FileName:string;
}