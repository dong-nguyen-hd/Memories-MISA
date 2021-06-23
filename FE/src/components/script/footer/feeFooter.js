export default {
    data: () => ({
        page: 1,
        pageSize: 10,
        firstPage: null,
        lastPage: null,
        totalPages: 0,
        totalRecords: 0,
        nextPage: null,
        previousPage: null,
        minimumSize: 10,
        maximumSize: 50,
        automaticSearchFeeName: null,

    }),
    computed: {
        /**
         * Tính toán dữ liệu cho "bắt đầu"
         * @returns dữ liệu sau khi tính toán
         */
        convertLowerDecimal() {
            if (!this.page)
                return 0;

            if (parseInt(this.page) == 1)
                return `0${this.page}`;
            else
                return `${parseInt(this.page - 1) * parseInt(this.pageSize) + 1}`;
        },
        /**
         * Tính toán dữ liệu cho "kết thúc"
         * @returns dữ liệu sau khi tính toán
         */
        pageSizeMask() {
            let tempData = (parseInt(this.page) * parseInt(this.pageSize));

            if (tempData > parseInt(this.totalRecords)) {
                if (parseInt(this.totalRecords) < 10)
                    return `0${this.totalRecords}`;
                else
                    return `${this.totalRecords}`;
            }
            else {
                return `${(parseInt(this.page) * parseInt(this.pageSize))}`;
            }

        },
        /**
         * Tính toán dữ liệu cho "tổng số"
         * @returns dữ liệu sau khi tính toán
         */
        totalRecordsMask() {
            if (parseInt(this.totalRecords) < 10)
                return `0${this.totalRecords}`;
            else
                return this.totalRecords;
        },
        /**
         * Tính toán dữ liệu cho "số trang"
         * @returns dữ liệu sau khi tính toán
         */
        countPage() {
            this.requestBody();

            if (parseInt(this.totalPages) < 5) {
                return this.totalPages;
            }
            else {
                let lenght = parseInt(this.totalPages);

                if (this.page >= 3 && this.page <= lenght - 2) {
                    let index = parseInt(this.page - 2);
                    return this.methodCountPage(index, lenght);
                }
                else if (this.page == lenght) {
                    let index = parseInt(this.page - 4);
                    return this.methodCountPage(index, lenght);
                }
                else if (this.page > lenght - 2) {
                    let index = parseInt(this.page - 3);
                    return this.methodCountPage(index, lenght);
                }
                else if (this.page > 1) {
                    let index = parseInt(this.page - 1);
                    return this.methodCountPage(index, lenght);
                }
                else {
                    let index = parseInt(this.page);
                    return this.methodCountPage(index, lenght);
                }
            }
        }
    },
    methods: {
        /**
         * Thực hiện lấY và gán trị trị từ store
         */
        requestBody() {
            this.page = this.$store.state.apiFee.responsePagination.page ? this.$store.state.apiFee.responsePagination.page : 0;
            this.pageSize = this.$store.state.apiFee.responsePagination.pageSize ? this.$store.state.apiFee.responsePagination.pageSize : 0;
            this.firstPage = this.$store.state.apiFee.responsePagination.firstPage;
            this.lastPage = this.$store.state.apiFee.responsePagination.lastPage;
            this.totalPages = this.$store.state.apiFee.responsePagination.totalPages ? this.$store.state.apiFee.responsePagination.totalPages : 0;
            this.totalRecords = this.$store.state.apiFee.responsePagination.totalRecords ? this.$store.state.apiFee.responsePagination.totalRecords : 0;
            this.nextPage = this.$store.state.apiFee.responsePagination.nextPage;
            this.previousPage = this.$store.state.apiFee.responsePagination.previousPage;
        },
        /**
         * Tạo và gán giá trị cho số nút chuyển trang
         * @param {Giá trị của nút} index 
         * @param {Số nút hiển thị} lenght 
         * @returns 
         */
        methodCountPage(index, lenght) {
            let list = [];
            let count = index + 5;
            while (index <= lenght) {
                if (index >= count)
                    break;

                list.push(index);
                index++;
            }
            return list;
        },
        /**
         * Thay đổi số bản ghi được hiển thị
         */
        changePageSize() {
            if (this.page >= this.totalPages)
                this.pageSize = 10;

            let timer = this.automaticSearchFeeName = Date.now();
            setTimeout(() => {
                if (timer == this.automaticSearchFeeName) {
                    this.$store.commit("changePageSize", this.pageSize);
                    this.$emit("movePage");
                }
            }, 600); // Thời gian nghỉ giữa mỗi lần gõ
        },
        /**
         * Gán giá trị class, style cho button chuyển trang
         * @param {Vị trí của nút chuyển trang} index 
         * @returns Giát trị class, style
         */
        indicialPage(index) {
            if (index == this.page)
                return "is-active btn-indicial-page pagination-btn";
            else
                return "btn-indicial-page pagination-btn";
        },
        /**
         * Chuyển tớI trang khác
         * @param {Chỉ định trang muốn chuyển tớI} movePage 
         */
        movePage(movePage) {
            let timer = this.automaticSearchFeeName = Date.now();
            setTimeout(() => {
                if (timer == this.automaticSearchFeeName) {
                    this.$store.commit("changePage", movePage);
                    this.$emit("movePage");
                }
            }, 40); // Thời gian nghỉ giữa mỗi lần gõ
        },
    },
    created() {
        this.requestBody()
    },
};