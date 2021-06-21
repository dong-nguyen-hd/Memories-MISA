<template>
  <div class="list-style" :class="isMinimize ? 'isMinimize' : ''">
    <!-- header of side bar -->
    <div id="header-block">
      <router-link to="/" class="header-block-logo">
        <img id="logo-icon" src="../assets/icon/ic_KhoanThu_56.svg" />
        <span>Khoản thu</span>
      </router-link>
      <router-link
        to="/"
        @click="isMinimize = !isMinimize"
        class="header-block-toggle"
      >
        <div class="img-toggle"></div>
      </router-link>
    </div>
    <!-- header of side bar -->

    <!-- list part -->
    <div class="list-block">
      <ul v-for="(item, i) in listCategory" :key="i">
        <router-link :to="item.route">
          <!-- checkingClick(i, true) with param loaded completion -->
          <li
            :class="item.active ? 'selected' : 'non-selection'"
            @click="checkingClick(i, isActive)"
          >
            <div
              class="icon-li"
              :style="`background: url(${item.pathImage}) ${item.position} no-repeat`"
            ></div>

            <span :class="item.active ? 'text-li-active text-li' : 'text-li'">{{
              item.nameCategory
            }}</span>
          </li>
        </router-link>
      </ul>
    </div>
    <!-- list part -->
  </div>
</template>
<style scoped src="./style/leftSideBar.css"></style>
<script src="./script/leftSideBar.js"></script>
