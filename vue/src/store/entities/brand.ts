import Entity from './entity'
export default class Brand extends Entity<number>
{
    BrandName:string;
    EngName:string;
    Spell:string;
    IsActive:boolean;
}