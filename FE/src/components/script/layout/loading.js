export default {
    props: {
        informationMessage: String
    },
    data: () => ({
        message: new String
    }),
    created() {
        if(this.informationMessage){
            this.message = this.informationMessage;
        }else{
            this.message = "Đang xử lí...";
        }
    },
    watch:{
        informationMessage: function(value){
            if(value){
                this.message = value;
            }
        }
    }
};