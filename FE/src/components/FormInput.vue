<template>
  <div class="main-content">
    <div class="bg-popup" :class="isLoading ? 'is-loading' : ''"></div>
    <div v-show="isLoading" class="wrap-information">
      <Loading :information-message="messageError"/>
    </div>

    <div class="popup">
      <div class="popup-header">
        <span>{{ title }}</span>
        <img @click="hidePopup" src="../assets/icon/ic_close_16.png" />
      </div>

      <div class="popup-content">
        <div class="content-scroll">
          <div class="content-one">
            <div class="block-input">
              <div class="input-fee-name">
                <label>Tên khoản thu <span class="required">*</span></label>
                <div
                  class="input-fee-name-content"
                  :class="isCheckFeeName ? '' : 'invalid'"
                >
                  <input v-model="fee.feeName" tabindex="1" type="text" />
                </div>
              </div>
            </div>

            <div class="block-input">
              <div class="input-fee-group">
                <div class="input-fee-group">
                  <label>Thuộc nhóm khoản thu</label>
                  <div class="input-fee-group-content">
                    <select tabindex="2" v-model="fee.feeGroupId">
                      <option
                        v-for="item in feeGroupList"
                        :key="item.feeGroupId"
                        :value="item.feeGroupId"
                      >
                        {{ item.feeGroupName }}
                      </option>
                    </select>

                    <div class="button-add-fee-group">
                      <img src="../assets/icon/ic_Plus.svg" />
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="block-input">
              <div class="input-fee-amount">
                <div class="child-fee-amount-one">
                  <label>Mức thu <span class="required">*</span></label>
                  <div
                    class="fee-amount-one-input"
                    :class="isCheckFeeAmount ? '' : 'invalid'"
                  >
                    <input tabindex="3" type="text" v-model="tempAmount" />
                  </div>
                </div>

                <div class="child-fee-amount-two">
                  <span>đ / </span>
                </div>

                <div class="child-fee-amount-three">
                  <label>Đơn vị tính <span class="required">*</span></label>
                  <div
                    class="fee-amount-three-input"
                    :class="isCheckFeeUnit ? '' : 'invalid'"
                  >
                    <select tabindex="4" v-model="fee.unitFeeId">
                      <option
                        v-for="item in unitFeeList"
                        :key="item.unitFeeId"
                        :value="item.unitFeeId"
                      >
                        {{ item.unitFeeName }}
                      </option>
                    </select>
                  </div>
                </div>
              </div>
            </div>

            <div class="block-input">
              <div class="input-fee-range">
                <label>Phạm vi thu <span class="required">*</span></label>
                <div
                  class="input-fee-range-content"
                  :class="isCheckFeeRange ? '' : 'invalid'"
                >
                  <select tabindex="5" v-model="fee.feeRangeId">
                    <option
                      v-for="item in feeRangeList"
                      :key="item.feeRangeId"
                      :value="item.feeRangeId"
                    >
                      {{ item.feeRangeName }}
                    </option>
                  </select>
                </div>
              </div>
            </div>

            <div class="block-input">
              <div class="input-fee-quality">
                <label>Tính chất</label>
                <div class="input-fee-quality-content">
                  <select tabindex="6" v-model="fee.quality">
                    <option
                      v-for="item in feeQualityList"
                      :key="item.id"
                      :value="item.id"
                    >
                      {{ item.name }}
                    </option>
                  </select>
                </div>
              </div>
            </div>

            <div class="block-input">
              <div class="input-turn-fee">
                <label>Kỳ thu <span class="required">*</span></label>
                <div class="input-turn-fee-content">
                  <div
                    class="input-checkbox-turn-fee"
                    v-for="(item, i) in turnFeeList"
                    :key="item.id"
                  >
                    <img
                      @click.self="checkTurnFeeClick(i, item)"
                      @keyup.enter="checkTurnFeeClick(i, item)"
                      :tabindex="7 + i"
                      v-if="!tempCheckTurnFee[i]"
                      class="ratio"
                      src="../assets/icon/ic_Ratio_Inactive.svg"
                    />
                    <img
                      @click.self="checkTurnFeeClick(i, item)"
                      @keyup.enter="checkTurnFeeClick(i, item)"
                      :tabindex="7 + i"
                      v-else
                      class="ratio"
                      src="../assets/icon/ic_Ratio_Active.svg"
                    />
                    <span>{{ item.name }}</span>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="content-two">
            <div class="block-one-content">
              <div class="boolean-content">
                <img
                  tabindex="11"
                  v-if="!fee.discount"
                  @click.self="feeDiscountChange()"
                  @keyup.enter="feeDiscountChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Inactive.svg"
                />
                <img
                  tabindex="11"
                  v-else
                  @click.self="feeDiscountChange()"
                  @keyup.enter="feeDiscountChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Active.svg"
                />
                <span>Áp dụng miễn giảm</span>
              </div>
              <div class="boolean-content">
                <img
                  tabindex="12"
                  v-if="!fee.feeRequired"
                  @click.self="feeRequiredChange()"
                  @keyup.enter="feeRequiredChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Inactive.svg"
                />
                <img
                  tabindex="12"
                  v-else
                  @click.self="feeRequiredChange()"
                  @keyup.enter="feeRequiredChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Active.svg"
                />
                <span>Khoản thu bắt buộc</span>
              </div>
              <div class="boolean-content">
                <img
                  tabindex="13"
                  v-if="!fee.allowExportBill"
                  @click.self="feeAllowExportBillChange()"
                  @keyup.enter="feeAllowExportBillChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Inactive.svg"
                />
                <img
                  v-else
                  tabindex="13"
                  @click.self="feeAllowExportBillChange()"
                  @keyup.enter="feeAllowExportBillChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Active.svg"
                />
                <span>Cho phép xuất hoá đơn</span>
              </div>
              <div class="boolean-content">
                <img
                  tabindex="14"
                  v-if="!fee.typeRegistion"
                  @click.self="feeTypeRegistionChange()"
                  @keyup.enter="feeTypeRegistionChange()"
                  class="boolean-switch"
                  src="../assets/icon/ic_Switch_Inactive.svg"
                />
                <img
                  tabindex="14"
                  v-else
                  @click.self="feeTypeRegistionChange()"
                  @keyup.enter="feeTypeRegistionChange()"
                  class="boolean-switch"
                  src="../assets/icon/ic_Switch_Active.png"
                />
                <span>Phân loại đăng ký</span>
              </div>
            </div>
            <div class="block-two-content">
              <div class="boolean-content">
                <img
                  tabindex="15"
                  v-if="!fee.allowExportLicense"
                  @click.self="feeAllowExportLicenseChange()"
                  @keyup.enter="feeAllowExportLicenseChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Inactive.svg"
                />
                <img
                  v-else
                  tabindex="15"
                  @click.self="feeAllowExportLicenseChange()"
                  @keyup.enter="feeAllowExportLicenseChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Active.svg"
                />
                <span>Cho phép xuất chứng từ</span>
              </div>
              <div class="boolean-content">
                <img
                  tabindex="16"
                  v-if="!fee.allowReturn"
                  @click.self="feeAllowReturnChange()"
                  @keyup.enter="feeAllowReturnChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Inactive.svg"
                />
                <img
                  tabindex="16"
                  v-else
                  @click.self="feeAllowReturnChange()"
                  @keyup.enter="feeAllowReturnChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Active.svg"
                />
                <span>Cho phép hoàn trả</span>
              </div>
              <div class="boolean-content">
                <img
                  tabindex="17"
                  v-if="!fee.feePrivate"
                  @click.self="feePrivateChange()"
                  @keyup.enter="feePrivateChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Inactive.svg"
                />
                <img
                  tabindex="17"
                  v-else
                  @click.self="feePrivateChange()"
                  @keyup.enter="feePrivateChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Active.svg"
                />
                <span>Thu nội bộ</span>
              </div>
              <div class="boolean-content">
                <img
                  tabindex="18"
                  v-if="fee.follow"
                  @click.self="feeFollowChange()"
                  @keyup.enter="feeFollowChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Inactive.svg"
                />
                <img
                  tabindex="18"
                  v-else
                  @click.self="feeFollowChange()"
                  @keyup.enter="feeFollowChange()"
                  class="boolean-check-box"
                  src="../assets/icon/ic_Checkbox_Active.svg"
                />
                <span>Theo dõi</span>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="popup-footer">
        <div
          @keyup.enter="save"
          @click.self="save"
          tabindex="20"
          class="button-footer button-save"
        >
          Lưu
        </div>
        <div
          v-if="hasSaveAsButton"
          tabindex="19"
          @click.self="saveAs"
          @keyup.enter="saveAs"
          class="button-footer button-save-as"
        >
          Lưu và thêm
        </div>
        <div
          tabindex="21"
          @click="hidePopup"
          @keyup.enter="hidePopup"
          class="button-footer button-close"
        >
          Đóng
        </div>
      </div>
    </div>
  </div>
</template>
<style scoped src="./style/formInput.css"></style>
<script src="./script/formInput.js"></script>
