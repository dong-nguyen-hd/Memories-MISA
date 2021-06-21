export default {
    data: function() {
        return {
            isActive: true,
            isMinimize: true,
            listCategory: [{
                    route: "/",
                    pathImage: require("../../../src/assets/icon/ic_sprites2.png"),
                    position: "-1057px -188px",
                    nameCategory: "Tổng quan",
                    active: false,
                },
                {
                    route: "/",
                    pathImage: require("../../../src/assets/icon/ic_sprites2.png"),
                    position: "0px -236px",
                    nameCategory: "Lập kế hoạch thu",
                    active: true,
                },
                {
                    route: "/",
                    pathImage: require("../../../src/assets/icon/ic_sprites2.png"),
                    position: "-432px -186px",
                    nameCategory: "Quản lí thu",
                    active: false,
                },
                {
                    route: "/",
                    pathImage: require("../../../src/assets/icon/ic_sprites2.png"),
                    position: "-1056px -44px",
                    nameCategory: "Quản lí hoá đơn",
                    active: false,
                },
                {
                    route: "/",
                    pathImage: require("../../../src/assets/icon/ic_sprites2.png"),
                    position: "-432px -186px",
                    nameCategory: "Số phải thu, phải trả",
                    active: false,
                },
                {
                    route: "/",
                    pathImage: require("../../../src/assets/icon/ic_sprites2.png"),
                    position: "-912px -189px",
                    nameCategory: "Báo cáo",
                    active: false,
                },
                {
                    route: "/",
                    pathImage: require("../../../src/assets/icon/ic_sprites2.png"),
                    position: "-432px -186px",
                    nameCategory: "Tin nhắn",
                    active: false,
                },
                {
                    route: "/",
                    pathImage: require("../../../src/assets/icon/ic_sprites2.png"),
                    position: "0px -283px",
                    nameCategory: "Hệ thống",
                    active: false,
                },

            ],
        };
    },
    methods: {
        checkingClick(indexValue, complete) {
            if (!this.listCategory[indexValue].active && complete) {
                // Remove class
                this.listCategory.forEach((item, index) => {
                    if (item.active && index != indexValue) {
                        item.active = false;
                    }
                });

                this.listCategory[indexValue].active = true;
                this.isActive = false;
            }

            // Avoid spam click
            setTimeout(() => {
                this.isActive = true;
            }, 300);
        },
    },
};