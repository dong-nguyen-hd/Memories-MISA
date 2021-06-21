<template>
  <div class="header-content">
    <!-- left part -->
    <div class="left-information">
      <span>{{headerText}}</span>
      <img v-tooltip.right="options" src="../assets/icon/ic_Info_20.svg">
    </div>
    <!-- left part -->

    <!-- right part -->
    <div class="right-information">
      <img class="avatar-img" src="../assets/icon/Avatar.png" />
      <img class="icon-search" src="../assets/icon/search.svg" />
      <div class="range-year" @click="checkingClick">
        <span>{{isSelected}}</span>
        <svg :class="isActive? 'isActive' :''"
          xmlns="http://www.w3.org/2000/svg"
          xmlns:xlink="http://www.w3.org/1999/xlink"
          version="1.1"
          width="24"
          height="24"
          viewBox="0 0 24 24"
        >
          <path
            d="M7.41,15.41L12,10.83L16.59,15.41L18,14L12,8L6,14L7.41,15.41Z"
          />
        </svg>
        <ul v-show="isActive">
          <li
            v-for="(item, i) in listData"
            :key="i"
            @click="setValue(item)"
          >
            {{ item }}
          </li>
        </ul>
      </div>

      <div class="school-information">
        <img src="../assets/icon/home.svg">
        <span>{{schoolName}}</span></div>
    </div>
  </div>
  <!-- right part -->
</template>
<style scoped src="./style/header.css"></style>
<script src="./script/header.js"></script>
