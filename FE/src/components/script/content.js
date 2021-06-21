export default {
    data: function() {
        return {
            contentTab: [{
                    id: 1,
                    name: "Quy trình",
                    isActive: false
                },
                {
                    id: 2,
                    name: "Danh sách khoản thu",
                    isActive: true
                },
                {
                    id: 3,
                    name: "Đăng kí khoản thu",
                    isActive: false
                },
                {
                    id: 4,
                    name: "Danh sách miễn giảm",
                    isActive: false
                },
            ],
            showUnder: true,
        };
    },
    methods: {
        checkingClick(indexValue) {
            if (!this.contentTab[indexValue].isActive) {
                // Remove class
                this.contentTab.forEach((item, index) => {
                    if (item.isActive && index != indexValue) {
                        item.isActive = false;
                    }
                });
                this.contentTab[indexValue].isActive = true;
            }

            // Checking show popup
            if (indexValue == 1)
                this.showUnder = true;
            else
                this.showUnder = false;
        },
    },
};