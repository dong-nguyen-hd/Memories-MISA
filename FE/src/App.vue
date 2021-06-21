<template>
  <div class="wrapper">
    <div class="left-side-bar">
      <left-side-bar/>
    </div>
    <div class="main">
      <div class="column header">
        <Header />
      </div>
      <div class="column content">
        <Content />
      </div>
    </div>
  </div>
</template>

<style>
* {
  margin: 0;
  padding: 0;
}

@font-face {
    font-family: opensans-regular;
    src: url(../src/assets/font/OpenSans-Regular.ttf);
}

@font-face {
    font-family: opensans-bold;
    src: url(../src/assets/font/OpenSans-Bold.ttf);
}

@font-face {
    font-family: opensans-semibold;
    src: url(../src/assets/font/OpenSans-Semibold.ttf);
}

.wrapper {
  width: 100%;
  height: 100%;
  display: flex;
  font-family: opensans-regular;
  overflow: hidden;
  color: #000;
}

.left-side-bar {
  width: 200px;
  height: 100vh;
}

.main {
  width: calc(100% - 200px);
  height: 100vh;
  position: relative;
}

.header {
  background-color: #ffffff;
  height: 48px;
  width: 100%;
  top: 0;
}

.content {
  background-color: #ffffff;
  top: 48px;
  bottom: 0;
  width: 100%;
}

.column {
  position: absolute;
}

/* tool tip */
.tooltip-reload {
    display: block !important;
    z-index: 10000;
}

.tooltip-reload .tooltip-inner {
    background: #24344B;
    color: #FFF;
    border-radius: 16px;
    padding: 5px 10px 4px;
}

.tooltip-reload .tooltip-arrow {
    width: 0;
    height: 0;
    border-style: solid;
    position: absolute;
    margin: 5px;
    border-color: black;
    z-index: 1;
}

.tooltip-reload[x-placement^="top"] {
    margin-bottom: 5px;
}

.tooltip-reload[x-placement^="top"] .tooltip-arrow {
    border-width: 5px 5px 0 5px;
    border-left-color: transparent !important;
    border-right-color: transparent !important;
    border-bottom-color: transparent !important;
    bottom: -5px;
    left: calc(50% - 5px);
    margin-top: 0;
    margin-bottom: 0;
}

.tooltip-reload[x-placement^="bottom"] {
    margin-top: 5px;
}

.tooltip-reload[x-placement^="bottom"] .tooltip-arrow {
    border-width: 0 5px 5px 5px;
    border-left-color: transparent !important;
    border-right-color: transparent !important;
    border-top-color: transparent !important;
    top: -5px;
    left: calc(50% - 5px);
    margin-top: 0;
    margin-bottom: 0;
}

.tooltip-reload[x-placement^="right"] {
    margin-left: 5px;
}

.tooltip-reload[x-placement^="right"] .tooltip-arrow {
    border-width: 5px 5px 5px 0;
    border-left-color: transparent !important;
    border-top-color: transparent !important;
    border-bottom-color: transparent !important;
    left: -5px;
    top: calc(50% - 5px);
    margin-left: 0;
    margin-right: 0;
}

.tooltip-reload[x-placement^="left"] {
    margin-right: 5px;
}

.tooltip-reload[x-placement^="left"] .tooltip-arrow {
    border-width: 5px 0 5px 5px;
    border-top-color: transparent !important;
    border-right-color: transparent !important;
    border-bottom-color: transparent !important;
    right: -5px;
    top: calc(50% - 5px);
    margin-left: 0;
    margin-right: 0;
}

.tooltip-reload.popover .popover-inner {
    background: #f9f9f9;
    color: black;
    padding: 24px;
    border-radius: 5px;
    box-shadow: 0 5px 30px rgba(black, .1);
}

.tooltip-reload.popover .popover-arrow {
    border-color: #f9f9f9;
}

.tooltip-reload[aria-hidden='true'] {
    visibility: hidden;
    opacity: 0;
    transition: opacity .15s, visibility .15s;
}

.tooltip-reload[aria-hidden='false'] {
    visibility: visible;
    opacity: 1;
    transition: opacity .15s;
}
</style>
