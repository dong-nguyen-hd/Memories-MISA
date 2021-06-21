<template>
  <div class="main-content">
    <!-- add/update dialog content -->
    <div class="content-popup" v-show="dialogActive">
      <form-input
        @emitShowPopup="dialogActive = $event"
        @addMethodFee="responseAddItem($event)"
        @saveAsMethodFee="responseSaveAs($event)"
        @updateMethodFee="responseUpdateItem($event)"
        :fee-prop="tempFee"
        :is-call-func="isFunc.isChosen"
      />
    </div>
    <!-- add/update dialog content -->
    
    <!-- confirm delete -->
    <div v-show="isShowDelete || isShowImportant || isShowLoading || isShowDeleteAll" class="bg-delete"></div>
    <div v-show="isShowDelete || isShowDeleteAll || isShowImportant" class="wrap-delete">
      <div class="pop-up-delete">
        <div class="delete-header">
          <span>Thông báo</span>
          <img @click.self="hidePopUpDelete" src="../assets/icon/ic_close_16.png">
        </div>
        <div class="delete-content">
          {{deleteMessage}}
        </div>
        <div class="delete-footer">
          <div v-if="isShowImportant" @click.self="hidePopUpDelete" class="delete-system">Đồng ý</div>
          <div v-if="isShowDelete" @click.self="deleteItem(0, true)" class="delete-yes">Xoá</div>
          <div v-if="isShowDeleteAll" @click.self="deleteAllItem(true)" class="delete-yes">Xoá</div>
          <div v-if="isShowDelete || isShowDeleteAll" @click.self="hidePopUpDelete" class="delete-no">Không</div>
          
        </div>
      </div>
    </div>
    <!-- confirm delete -->

    <Loading v-show="isShowLoading" :information-message="messageError"/>

    <!-- list content -->
    <div class="content-upper">
      <div class="content-left">
        <!-- Button show follow -->
        <div class="left-check-box" @click="showFollow">
          <img
            v-show="!isShowFollow"
            src="../assets/icon/ic_Checkbox_Inactive.svg"
            class="left-check-box-border"
          />
          <img
            v-show="isShowFollow"
            src="../assets/icon/ic_Checkbox_Active.svg"
            class="left-check-box-content"
          />
        </div>
        <div class="left-text">
          <span>Hiển thị khoản thu ngừng theo dõi</span>
        </div>
        <!-- Button show follow -->
      </div>

      <div class="content-right">
        <!-- Delete all -->
        <div
          v-tooltip.top-left="options"
          @click="deleteAllItem(false)"
          class="right-delete-all"
        >
          <img src="../assets/icon/ic_Delete_32.svg" />
        </div>
        <!-- Delete all -->

        <!-- Reload -->
        <div class="right-reorder" @click="reloadFee">
          <span>Sắp xếp lại thứ tự</span>
        </div>
        <!-- Reload -->

        <!-- Add -->
        <div class="right-add" @click="callFuncDiaglog(false, null)">
          <span>Thêm mới</span>
        </div>
        <!-- Add -->
      </div>
    </div>

    <div class="content-under">
      <div class="list-items">
        <table>
          <thead>
            <tr>
              <th class="table-check-box-all">
                <img
                  @click.self="selectDeleteAll"
                  v-if="!booleanDeleteAll"
                  src="../assets/icon/ic_Checkbox_Inactive.svg"
                  class="table-check-box-border-all"
                />
                <img
                  v-else
                  @click.self="selectDeleteAll"
                  src="../assets/icon/ic_Checkbox_Active.svg"
                  class="table-check-box-content-all"
                />
              </th>
              <th>
                <span>Tên khoản thu</span>
                <div class="th-fee-name-search">
                  <img src="../assets/icon/ic_Filter.svg" />
                  <input
                    v-model="feeNameModel"
                    v-on:keyup="invokeSearchFeeName"
                    type="text"
                  />
                </div>
              </th>
              <th>
                <span>Nhóm khoản thu</span>
                <div class="th-fee-group-search">
                  <img src="../assets/icon/ic_Filter.svg" />
                  <input
                    v-model="feeGroupModel"
                    v-on:keyup="invokeSearchFeeGroup"
                    type="text"
                  />
                </div>
              </th>
              <th>
                <span>Mức thu</span>
                <div class="th-fee-amount-search">
                  <img src="../assets/icon/ic_Filter.svg" />
                  <input
                    v-model="feeAmountModel"
                    v-on:keyup="invokeSearchFeeAmount"
                    type="text"
                  />
                </div>
              </th>
              <th>
                <span>Kỳ thu</span>
                <div class="th-turn-fee-search" @click="turnFeeClicking">
                  <div class="th-turn-fee-text">{{ isSelectedTurnFee }}</div>
                  <svg
                    :class="isActiveTurnFee ? 'active-turn-fee' : ''"
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
                  <ul v-show="isActiveTurnFee">
                    <li
                      v-for="item in turnFeeList"
                      :key="item.id"
                      @click="invokeSearchTurnFee(item)"
                    >
                      {{ item.name }}
                    </li>
                  </ul>
                </div>
              </th>
              <th>
                <span>Phạm vi thu</span>
                <div class="th-fee-range-search">
                  <img src="../assets/icon/ic_Filter.svg" />
                  <input
                    v-model="feeRangeModel"
                    v-on:keyup="invokeSearchFeeRange"
                    type="text"
                  />
                </div>
              </th>
              <th class="th-fee-boolean">Áp dụng miễn giảm</th>
              <th class="th-fee-boolean">Cho xuất hoá đơn</th>
              <th class="th-fee-boolean">Cho xuất chứng từ</th>
              <th class="th-fee-boolean">Cho phép hoàn trả</th>
              <th class="th-fee-boolean">Khoản thu bắt buộc</th>
              <th class="th-fee-boolean">Đang theo dõi</th>
              <th class="th-fee-boolean">Tính năng</th>
            </tr>
          </thead>
          <tbody v-show="fee">
            <tr
              v-for="(item, i) in fee"
              :key="item.id"
              :class="i % 2 == 0 ? 'isBold' : ''"
            >
              <td>
                <div class="table-check-box-all">
                  <img
                    @click.self="selectDelete(i)"
                    v-if="!deleteList[i]"
                    src="../assets/icon/ic_Checkbox_Inactive.svg"
                    class="check-box-border-td"
                  />
                  <img
                    v-else
                    @click.self="selectDelete(i)"
                    src="../assets/icon/ic_Checkbox_Active.svg"
                    class="check-box-content-td"
                  />
                </div>
              </td>

              <td :style="'cursor: pointer;'" v-if="item.feeName" @click="callFuncDiaglog(true, item)">
                <span class="fee-name-col">{{ item.feeName }}</span>
                <img
                  v-if="item.important"
                  class="fee-name-important-icon"
                  v-tooltip.right="{content: 'Dữ liệu của hệ thống, không được phép xoá', autoHide: false, classes: 'tooltip-reload'}"
                  src="../assets/icon/ic_Info_20.svg"
                />
              </td>
              <td
                :style="'cursor: pointer;'"
                v-else
                @click="callFuncDiaglog(true, item)"
              ></td>

              <td v-if="item.feeGroup">
                {{ item.feeGroup.feeGroupName }}
              </td>
              <td v-else></td>

              <td class="content-align-right">
                {{
                  `${formatMoney(item.amountOfFee)}/${unitFeeIdToText(
                    item.unitFee.unitFeeId
                  )}`
                }}
              </td>

              <td>
                {{ turnFeeIdToText(item.turnFee) }}
              </td>

              <td v-if="item.feeRange">
                {{ item.feeRange.feeRangeName }}
              </td>
              <td v-else></td>

              <td :class="item.discount ? 'td-boolean-check' : ''"></td>

              <td :class="item.allowExportBill ? 'td-boolean-check' : ''"></td>

              <td
                :class="item.allowExportLicense ? 'td-boolean-check' : ''"
              ></td>

              <td :class="item.allowReturn ? 'td-boolean-check' : ''"></td>

              <td :class="item.important ? 'td-boolean-check' : ''"></td>

              <td :class="!item.follow ? 'td-boolean-check' : ''"></td>

              <td>
                <div class="content-align-func">
                  <img
                    v-tooltip.left="{content: 'Chỉnh sửa khoản thu', autoHide: false, classes: 'tooltip-reload'}"
                    @click.self="callFuncDiaglog(true, item)"
                    class="edit-func"
                    src="../assets/icon/ic_Edit.svg"
                  />
                  <img
                    v-tooltip.left="{content: 'Sao chép dữ liệu và tạo mới', autoHide: false, classes: 'tooltip-reload'}"
                    @click.self="callFuncDiaglog(false, item)"
                    class="copy-func"
                    src="../assets/icon/ic_Duplicate_24.svg"
                  />
                  <img
                    v-tooltip.left="{content: 'Xoá khoản thu', autoHide: false, classes: 'tooltip-reload'}"
                    @click.self="deleteItem(i, false)"
                    class="delete-func"
                    src="../assets/icon/ic_Delete_32.svg"
                  />
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <!-- list content -->

    <!-- footer content -->
    <div class="content-footer">
      <Footer @movePage="requestFee()" />
    </div>
    <!-- footer content -->
  </div>
</template>
<style scoped src="./style/feeList.css"></style>
<script src="./script/feeList.js"></script>


