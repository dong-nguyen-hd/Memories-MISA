export default {
    data: () => ({
        listData: [
            "2019 - 2020",
            "2020 - 2021",
            "2021 - 2022",
            "2022 - 2023",
        ],
        isSelected: "2020 - 2021",
        isActive: false,
        schoolName: "[Thí điểm] Trường mẫu giáo Nguyễn Duy Đông",
        headerText: "Lập kế hoạch thu",
        options: {
            autoHide: false,
            content: "Trang lập kế hoạch thu",
            classes: "tooltip-reload"
        }
    }),
    methods: {
        /**
         * Thay đổi giá trị boolean true/false
         */
        checkingClick() {
            this.isActive = !this.isActive;
        },
        /**
         * Gán giá trị mong muốn
         * @param {Giá trị muốn gán} item 
         */
        setValue(item) {
            this.isSelected = item;
        },
    },
};