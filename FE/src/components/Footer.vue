<template>
  <div class="footer-content">
    <div class="block-edge">
      <div class="count-pages">
        Hiển thị
        <span>
          {{ convertLowerDecimal }}-{{ pageSizeMask }}/{{
            totalRecordsMask
          }}
        </span>
        khoản thu
      </div>
      <div class="size-per-page">
        <div class="block-size-per-page">
          <input v-model="pageSize" 
          @change="changePageSize" 
          type="number" 
          :min="minimumSize" 
          :max="maximumSize"/>
          <span>khoản thu/trang</span>
        </div>
      </div>
    </div>

    <div class="pagination-button">
      <div @click="movePage(firstPage)" class="btn-first-page pagination-btn">
        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevrons-left"><polyline points="11 17 6 12 11 7"></polyline><polyline points="18 17 13 12 18 7"></polyline></svg>
      </div>
      <div @click="movePage(previousPage)" class="btn-previous-page pagination-btn">
        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevron-left"><polyline points="15 18 9 12 15 6"></polyline></svg>
      </div>
      <div v-for="item in countPage" :key="item" @click="movePage(item)" :class="indicialPage(item)">{{item}}</div>
      <div @click="movePage(nextPage)" class="btn-next-page pagination-btn">
        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevron-right"><polyline points="9 18 15 12 9 6"></polyline></svg>
      </div>
      <div @click="movePage(lastPage)" class="btn-last-page pagination-btn">
        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevrons-right"><polyline points="13 17 18 12 13 7"></polyline><polyline points="6 17 11 12 6 7"></polyline></svg>
      </div>
    </div>
  </div>
</template>
<style scoped src="./style/footer.css"></style>
<script src="./script/footer.js"></script>