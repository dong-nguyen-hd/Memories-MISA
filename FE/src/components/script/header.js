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
        checkingClick() {
            this.isActive = !this.isActive;
        },
        setValue(item) {
            this.isSelected = item;
        },
    },
};