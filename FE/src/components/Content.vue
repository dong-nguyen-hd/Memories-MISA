<template>
  <div class="main-content">
    <div class="content-upper">
      <div class="content-tab" v-for="(item, i) in contentTab" :key="i">
        <div
          class="inside-tab"
          :class="item.isActive ? 'active' : ''"
          @click="checkingClick(i)"
        >
          {{ item.name }}
        </div>
      </div>
    </div>
    <div class="content-under">
      <fee-list v-show="showUnder"/>
      <div v-show="!showUnder" class="anonymous-tab">
        <span>Tính năng đang phát triển, vui lòng quay lại sau!</span>
        </div>
    </div>
  </div>
</template>
<style scoped src="./style/content.css"></style>
<script src="./script/content.js"></script>


