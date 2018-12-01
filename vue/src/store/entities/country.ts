import Entity from './entity'
export default class Country extends Entity<number>
{
    CountryCode?:string;
    CountryName:string;
    CountryShort:string;
    ChineseName:string;
    EnglishName:string;
    IsActive:boolean;
}