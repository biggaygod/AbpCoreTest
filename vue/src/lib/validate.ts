import AbpBase from './abpbase';
class validate extends AbpBase{
    //手机号验证
    TelCheck = (rule:any, value:any, callback:any) => {
        const myreg:RegExp=/^[1][3,4,5,7,8][0-9]{9}$/;
        if (!value) {
            callback(new Error(this.L('FieldIsRequired')));
        } else if (!myreg.test(value)) {
            callback(new Error(this.L('ConfirmTelNotMatch')));
        } else
        {
            callback()
        }
    };
    //邮箱验证
    EmailCheck = (rule:any, value:any, callback:any) => {
        const myreg:RegExp=/^[A-Za-z\d]+([-_.][A-Za-z\d]+)*@([A-Za-z\d]+[-.])+[A-Za-z\d]{2,4}$/;
        if (!value) {
            callback(new Error(this.L('FieldIsRequired')));
        } else if (!myreg.test(value)) {
            callback(new Error(this.L('ConfirmEmaiNotMatch')));
        } else
        {
            callback()
        }
    };
}
const Validate=new validate();
export default Validate;