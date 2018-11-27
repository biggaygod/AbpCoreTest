import Entity from './entity'
export default class Brand extends Entity<number>
{
    CountryCode:string;
    BrandName:string;
    EngName:string;
    Spell:string;
    IsActive:boolean;
}