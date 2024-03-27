namespace FreeScheduler.Login.Dashboard
{
    public static class LoginViews
    {
        public static string Login { get; private set; } = @"<html lang=""en"">

<head>
  <script type=""module"" src=""/@vite/client""></script>

  <meta charset=""UTF-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
  <title>Scheduler</title>
  <style type=""text/css"" data-vite-dev-id=""E:/code/test/ui/panda.net.web/src/assets/main.css"">
    /* color palette from <https://github.com/vuejs/theme> */
    :root {
      --vt-c-white: #ffffff;
      --vt-c-white-soft: #f8f8f8;
      --vt-c-white-mute: #f2f2f2;

      --vt-c-black: #181818;
      --vt-c-black-soft: #222222;
      --vt-c-black-mute: #282828;

      --vt-c-indigo: #2c3e50;

      --vt-c-divider-light-1: rgba(60, 60, 60, 0.29);
      --vt-c-divider-light-2: rgba(60, 60, 60, 0.12);
      --vt-c-divider-dark-1: rgba(84, 84, 84, 0.65);
      --vt-c-divider-dark-2: rgba(84, 84, 84, 0.48);

      --vt-c-text-light-1: var(--vt-c-indigo);
      --vt-c-text-light-2: rgba(60, 60, 60, 0.66);
      --vt-c-text-dark-1: var(--vt-c-white);
      --vt-c-text-dark-2: rgba(235, 235, 235, 0.64);
    }

    /* semantic color variables for this project */
    :root {
      --color-background: var(--vt-c-white);
      --color-background-soft: var(--vt-c-white-soft);
      --color-background-mute: var(--vt-c-white-mute);

      --color-border: var(--vt-c-divider-light-2);
      --color-border-hover: var(--vt-c-divider-light-1);

      --color-heading: var(--vt-c-text-light-1);
      --color-text: var(--vt-c-text-light-1);

      --section-gap: 160px;
    }

    @media (prefers-color-scheme: dark) {
      :root {
        --color-background: var(--vt-c-black);
        --color-background-soft: var(--vt-c-black-soft);
        --color-background-mute: var(--vt-c-black-mute);

        --color-border: var(--vt-c-divider-dark-2);
        --color-border-hover: var(--vt-c-divider-dark-1);

        --color-heading: var(--vt-c-text-dark-1);
        --color-text: var(--vt-c-text-dark-2);
      }
    }

    *,
    *::before,
    *::after {
      box-sizing: border-box;
      margin: 0;
      font-weight: normal;
    }

    body {
      min-height: 100vh;
      color: var(--color-text);
      background: var(--color-background);
      transition:
        color 0.5s,
        background-color 0.5s;
      line-height: 1.6;
      font-family:
        Inter,
        -apple-system,
        BlinkMacSystemFont,
        'Segoe UI',
        Roboto,
        Oxygen,
        Ubuntu,
        Cantarell,
        'Fira Sans',
        'Droid Sans',
        'Helvetica Neue',
        sans-serif;
      font-size: 15px;
      text-rendering: optimizeLegibility;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
    }

    .app {
      font-weight: normal;
    }

    a,
    .green {
      text-decoration: none;
      color: hsla(160, 100%, 37%, 1);
      transition: 0.4s;
      padding: 3px;
    }

    @media (hover: hover) {
      a:hover {
        background-color: hsla(160, 100%, 37%, 0.2);
      }
    }
  </style>
  <style type=""text/css"" data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/dist/index.css"">
    @charset ""UTF-8"";

    :root {
      --el-color-white: #ffffff;
      --el-color-black: #000000;
      --el-color-primary-rgb: 64, 158, 255;
      --el-color-success-rgb: 103, 194, 58;
      --el-color-warning-rgb: 230, 162, 60;
      --el-color-danger-rgb: 245, 108, 108;
      --el-color-error-rgb: 245, 108, 108;
      --el-color-info-rgb: 144, 147, 153;
      --el-font-size-extra-large: 20px;
      --el-font-size-large: 18px;
      --el-font-size-medium: 16px;
      --el-font-size-base: 14px;
      --el-font-size-small: 13px;
      --el-font-size-extra-small: 12px;
      --el-font-family: 'Helvetica Neue', Helvetica, 'PingFang SC', 'Hiragino Sans GB', 'Microsoft YaHei', '微软雅黑', Arial, sans-serif;
      --el-font-weight-primary: 500;
      --el-font-line-height-primary: 24px;
      --el-index-normal: 1;
      --el-index-top: 1000;
      --el-index-popper: 2000;
      --el-border-radius-base: 4px;
      --el-border-radius-small: 2px;
      --el-border-radius-round: 20px;
      --el-border-radius-circle: 100%;
      --el-transition-duration: 0.3s;
      --el-transition-duration-fast: 0.2s;
      --el-transition-function-ease-in-out-bezier: cubic-bezier(0.645, 0.045, 0.355, 1);
      --el-transition-function-fast-bezier: cubic-bezier(0.23, 1, 0.32, 1);
      --el-transition-all: all var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-fade: opacity var(--el-transition-duration) var(--el-transition-function-fast-bezier);
      --el-transition-md-fade: transform var(--el-transition-duration) var(--el-transition-function-fast-bezier), opacity var(--el-transition-duration) var(--el-transition-function-fast-bezier);
      --el-transition-fade-linear: opacity var(--el-transition-duration-fast) linear;
      --el-transition-border: border-color var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-box-shadow: box-shadow var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-color: color var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-component-size-large: 40px;
      --el-component-size: 32px;
      --el-component-size-small: 24px
    }

    :root {
      color-scheme: light;
      --el-color-white: #ffffff;
      --el-color-black: #000000;
      --el-color-primary: #409eff;
      --el-color-primary-light-3: #79bbff;
      --el-color-primary-light-5: #a0cfff;
      --el-color-primary-light-7: #c6e2ff;
      --el-color-primary-light-8: #d9ecff;
      --el-color-primary-light-9: #ecf5ff;
      --el-color-primary-dark-2: #337ecc;
      --el-color-success: #67c23a;
      --el-color-success-light-3: #95d475;
      --el-color-success-light-5: #b3e19d;
      --el-color-success-light-7: #d1edc4;
      --el-color-success-light-8: #e1f3d8;
      --el-color-success-light-9: #f0f9eb;
      --el-color-success-dark-2: #529b2e;
      --el-color-warning: #e6a23c;
      --el-color-warning-light-3: #eebe77;
      --el-color-warning-light-5: #f3d19e;
      --el-color-warning-light-7: #f8e3c5;
      --el-color-warning-light-8: #faecd8;
      --el-color-warning-light-9: #fdf6ec;
      --el-color-warning-dark-2: #b88230;
      --el-color-danger: #f56c6c;
      --el-color-danger-light-3: #f89898;
      --el-color-danger-light-5: #fab6b6;
      --el-color-danger-light-7: #fcd3d3;
      --el-color-danger-light-8: #fde2e2;
      --el-color-danger-light-9: #fef0f0;
      --el-color-danger-dark-2: #c45656;
      --el-color-error: #f56c6c;
      --el-color-error-light-3: #f89898;
      --el-color-error-light-5: #fab6b6;
      --el-color-error-light-7: #fcd3d3;
      --el-color-error-light-8: #fde2e2;
      --el-color-error-light-9: #fef0f0;
      --el-color-error-dark-2: #c45656;
      --el-color-info: #909399;
      --el-color-info-light-3: #b1b3b8;
      --el-color-info-light-5: #c8c9cc;
      --el-color-info-light-7: #dedfe0;
      --el-color-info-light-8: #e9e9eb;
      --el-color-info-light-9: #f4f4f5;
      --el-color-info-dark-2: #73767a;
      --el-bg-color: #ffffff;
      --el-bg-color-page: #f2f3f5;
      --el-bg-color-overlay: #ffffff;
      --el-text-color-primary: #303133;
      --el-text-color-regular: #606266;
      --el-text-color-secondary: #909399;
      --el-text-color-placeholder: #a8abb2;
      --el-text-color-disabled: #c0c4cc;
      --el-border-color: #dcdfe6;
      --el-border-color-light: #e4e7ed;
      --el-border-color-lighter: #ebeef5;
      --el-border-color-extra-light: #f2f6fc;
      --el-border-color-dark: #d4d7de;
      --el-border-color-darker: #cdd0d6;
      --el-fill-color: #f0f2f5;
      --el-fill-color-light: #f5f7fa;
      --el-fill-color-lighter: #fafafa;
      --el-fill-color-extra-light: #fafcff;
      --el-fill-color-dark: #ebedf0;
      --el-fill-color-darker: #e6e8eb;
      --el-fill-color-blank: #ffffff;
      --el-box-shadow: 0px 12px 32px 4px rgba(0, 0, 0, 0.04), 0px 8px 20px rgba(0, 0, 0, 0.08);
      --el-box-shadow-light: 0px 0px 12px rgba(0, 0, 0, 0.12);
      --el-box-shadow-lighter: 0px 0px 6px rgba(0, 0, 0, 0.12);
      --el-box-shadow-dark: 0px 16px 48px 16px rgba(0, 0, 0, 0.08), 0px 12px 32px rgba(0, 0, 0, 0.12), 0px 8px 16px -8px rgba(0, 0, 0, 0.16);
      --el-disabled-bg-color: var(--el-fill-color-light);
      --el-disabled-text-color: var(--el-text-color-placeholder);
      --el-disabled-border-color: var(--el-border-color-light);
      --el-overlay-color: rgba(0, 0, 0, 0.8);
      --el-overlay-color-light: rgba(0, 0, 0, 0.7);
      --el-overlay-color-lighter: rgba(0, 0, 0, 0.5);
      --el-mask-color: rgba(255, 255, 255, 0.9);
      --el-mask-color-extra-light: rgba(255, 255, 255, 0.3);
      --el-border-width: 1px;
      --el-border-style: solid;
      --el-border-color-hover: var(--el-text-color-disabled);
      --el-border: var(--el-border-width) var(--el-border-style) var(--el-border-color);
      --el-svg-monochrome-grey: var(--el-border-color)
    }

    .fade-in-linear-enter-active,
    .fade-in-linear-leave-active {
      transition: var(--el-transition-fade-linear)
    }

    .fade-in-linear-enter-from,
    .fade-in-linear-leave-to {
      opacity: 0
    }

    .el-fade-in-linear-enter-active,
    .el-fade-in-linear-leave-active {
      transition: var(--el-transition-fade-linear)
    }

    .el-fade-in-linear-enter-from,
    .el-fade-in-linear-leave-to {
      opacity: 0
    }

    .el-fade-in-enter-active,
    .el-fade-in-leave-active {
      transition: all var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-fade-in-enter-from,
    .el-fade-in-leave-active {
      opacity: 0
    }

    .el-zoom-in-center-enter-active,
    .el-zoom-in-center-leave-active {
      transition: all var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-zoom-in-center-enter-from,
    .el-zoom-in-center-leave-active {
      opacity: 0;
      transform: scaleX(0)
    }

    .el-zoom-in-top-enter-active,
    .el-zoom-in-top-leave-active {
      opacity: 1;
      transform: scaleY(1);
      transition: var(--el-transition-md-fade);
      transform-origin: center top
    }

    .el-zoom-in-top-enter-active[data-popper-placement^=top],
    .el-zoom-in-top-leave-active[data-popper-placement^=top] {
      transform-origin: center bottom
    }

    .el-zoom-in-top-enter-from,
    .el-zoom-in-top-leave-active {
      opacity: 0;
      transform: scaleY(0)
    }

    .el-zoom-in-bottom-enter-active,
    .el-zoom-in-bottom-leave-active {
      opacity: 1;
      transform: scaleY(1);
      transition: var(--el-transition-md-fade);
      transform-origin: center bottom
    }

    .el-zoom-in-bottom-enter-from,
    .el-zoom-in-bottom-leave-active {
      opacity: 0;
      transform: scaleY(0)
    }

    .el-zoom-in-left-enter-active,
    .el-zoom-in-left-leave-active {
      opacity: 1;
      transform: scale(1, 1);
      transition: var(--el-transition-md-fade);
      transform-origin: top left
    }

    .el-zoom-in-left-enter-from,
    .el-zoom-in-left-leave-active {
      opacity: 0;
      transform: scale(.45, .45)
    }

    .collapse-transition {
      transition: var(--el-transition-duration) height ease-in-out, var(--el-transition-duration) padding-top ease-in-out, var(--el-transition-duration) padding-bottom ease-in-out
    }

    .el-collapse-transition-enter-active,
    .el-collapse-transition-leave-active {
      transition: var(--el-transition-duration) max-height ease-in-out, var(--el-transition-duration) padding-top ease-in-out, var(--el-transition-duration) padding-bottom ease-in-out
    }

    .horizontal-collapse-transition {
      transition: var(--el-transition-duration) width ease-in-out, var(--el-transition-duration) padding-left ease-in-out, var(--el-transition-duration) padding-right ease-in-out
    }

    .el-list-enter-active,
    .el-list-leave-active {
      transition: all 1s
    }

    .el-list-enter-from,
    .el-list-leave-to {
      opacity: 0;
      transform: translateY(-30px)
    }

    .el-list-leave-active {
      position: absolute !important
    }

    .el-opacity-transition {
      transition: opacity var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-icon-loading {
      -webkit-animation: rotating 2s linear infinite;
      animation: rotating 2s linear infinite
    }

    .el-icon--right {
      margin-left: 5px
    }

    .el-icon--left {
      margin-right: 5px
    }

    @-webkit-keyframes rotating {
      0% {
        transform: rotateZ(0)
      }

      100% {
        transform: rotateZ(360deg)
      }
    }

    @keyframes rotating {
      0% {
        transform: rotateZ(0)
      }

      100% {
        transform: rotateZ(360deg)
      }
    }

    .el-icon {
      --color: inherit;
      height: 1em;
      width: 1em;
      line-height: 1em;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      position: relative;
      fill: currentColor;
      color: var(--color);
      font-size: inherit
    }

    .el-icon.is-loading {
      -webkit-animation: rotating 2s linear infinite;
      animation: rotating 2s linear infinite
    }

    .el-icon svg {
      height: 1em;
      width: 1em
    }

    .el-affix--fixed {
      position: fixed
    }

    .el-alert {
      --el-alert-padding: 8px 16px;
      --el-alert-border-radius-base: var(--el-border-radius-base);
      --el-alert-title-font-size: 13px;
      --el-alert-description-font-size: 12px;
      --el-alert-close-font-size: 12px;
      --el-alert-close-customed-font-size: 13px;
      --el-alert-icon-size: 16px;
      --el-alert-icon-large-size: 28px;
      width: 100%;
      padding: var(--el-alert-padding);
      margin: 0;
      box-sizing: border-box;
      border-radius: var(--el-alert-border-radius-base);
      position: relative;
      background-color: var(--el-color-white);
      overflow: hidden;
      opacity: 1;
      display: flex;
      align-items: center;
      transition: opacity var(--el-transition-duration-fast)
    }

    .el-alert.is-light .el-alert__close-btn {
      color: var(--el-text-color-placeholder)
    }

    .el-alert.is-dark .el-alert__close-btn {
      color: var(--el-color-white)
    }

    .el-alert.is-dark .el-alert__description {
      color: var(--el-color-white)
    }

    .el-alert.is-center {
      justify-content: center
    }

    .el-alert--success {
      --el-alert-bg-color: var(--el-color-success-light-9)
    }

    .el-alert--success.is-light {
      background-color: var(--el-alert-bg-color);
      color: var(--el-color-success)
    }

    .el-alert--success.is-light .el-alert__description {
      color: var(--el-color-success)
    }

    .el-alert--success.is-dark {
      background-color: var(--el-color-success);
      color: var(--el-color-white)
    }

    .el-alert--info {
      --el-alert-bg-color: var(--el-color-info-light-9)
    }

    .el-alert--info.is-light {
      background-color: var(--el-alert-bg-color);
      color: var(--el-color-info)
    }

    .el-alert--info.is-light .el-alert__description {
      color: var(--el-color-info)
    }

    .el-alert--info.is-dark {
      background-color: var(--el-color-info);
      color: var(--el-color-white)
    }

    .el-alert--warning {
      --el-alert-bg-color: var(--el-color-warning-light-9)
    }

    .el-alert--warning.is-light {
      background-color: var(--el-alert-bg-color);
      color: var(--el-color-warning)
    }

    .el-alert--warning.is-light .el-alert__description {
      color: var(--el-color-warning)
    }

    .el-alert--warning.is-dark {
      background-color: var(--el-color-warning);
      color: var(--el-color-white)
    }

    .el-alert--error {
      --el-alert-bg-color: var(--el-color-error-light-9)
    }

    .el-alert--error.is-light {
      background-color: var(--el-alert-bg-color);
      color: var(--el-color-error)
    }

    .el-alert--error.is-light .el-alert__description {
      color: var(--el-color-error)
    }

    .el-alert--error.is-dark {
      background-color: var(--el-color-error);
      color: var(--el-color-white)
    }

    .el-alert__content {
      display: table-cell;
      padding: 0 8px
    }

    .el-alert .el-alert__icon {
      font-size: var(--el-alert-icon-size);
      width: var(--el-alert-icon-size)
    }

    .el-alert .el-alert__icon.is-big {
      font-size: var(--el-alert-icon-large-size);
      width: var(--el-alert-icon-large-size)
    }

    .el-alert__title {
      font-size: var(--el-alert-title-font-size);
      line-height: 18px;
      vertical-align: text-top
    }

    .el-alert__title.is-bold {
      font-weight: 700
    }

    .el-alert .el-alert__description {
      font-size: var(--el-alert-description-font-size);
      margin: 5px 0 0 0
    }

    .el-alert .el-alert__close-btn {
      font-size: var(--el-alert-close-font-size);
      opacity: 1;
      position: absolute;
      top: 12px;
      right: 15px;
      cursor: pointer
    }

    .el-alert .el-alert__close-btn.is-customed {
      font-style: normal;
      font-size: var(--el-alert-close-customed-font-size);
      top: 9px
    }

    .el-alert-fade-enter-from,
    .el-alert-fade-leave-active {
      opacity: 0
    }

    .el-aside {
      overflow: auto;
      box-sizing: border-box;
      flex-shrink: 0;
      width: var(--el-aside-width, 300px)
    }

    .el-autocomplete {
      position: relative;
      display: inline-block
    }

    .el-autocomplete__popper.el-popper {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-border-color-light);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-autocomplete__popper.el-popper .el-popper__arrow::before {
      border: 1px solid var(--el-border-color-light)
    }

    .el-autocomplete__popper.el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-autocomplete__popper.el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-autocomplete__popper.el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-autocomplete__popper.el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-autocomplete-suggestion {
      border-radius: var(--el-border-radius-base);
      box-sizing: border-box
    }

    .el-autocomplete-suggestion__wrap {
      max-height: 280px;
      padding: 10px 0;
      box-sizing: border-box
    }

    .el-autocomplete-suggestion__list {
      margin: 0;
      padding: 0
    }

    .el-autocomplete-suggestion li {
      padding: 0 20px;
      margin: 0;
      line-height: 34px;
      cursor: pointer;
      color: var(--el-text-color-regular);
      font-size: var(--el-font-size-base);
      list-style: none;
      text-align: left;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis
    }

    .el-autocomplete-suggestion li:hover {
      background-color: var(--el-fill-color-light)
    }

    .el-autocomplete-suggestion li.highlighted {
      background-color: var(--el-fill-color-light)
    }

    .el-autocomplete-suggestion li.divider {
      margin-top: 6px;
      border-top: 1px solid var(--el-color-black)
    }

    .el-autocomplete-suggestion li.divider:last-child {
      margin-bottom: -6px
    }

    .el-autocomplete-suggestion.is-loading li {
      text-align: center;
      height: 100px;
      line-height: 100px;
      font-size: 20px;
      color: var(--el-text-color-secondary)
    }

    .el-autocomplete-suggestion.is-loading li::after {
      display: inline-block;
      content: """";
      height: 100%;
      vertical-align: middle
    }

    .el-autocomplete-suggestion.is-loading li:hover {
      background-color: var(--el-bg-color-overlay)
    }

    .el-autocomplete-suggestion.is-loading .el-icon-loading {
      vertical-align: middle
    }

    .el-avatar {
      --el-avatar-text-color: var(--el-color-white);
      --el-avatar-bg-color: var(--el-text-color-disabled);
      --el-avatar-text-size: 14px;
      --el-avatar-icon-size: 18px;
      --el-avatar-border-radius: var(--el-border-radius-base);
      --el-avatar-size-large: 56px;
      --el-avatar-size: 40px;
      --el-avatar-size-small: 24px;
      --el-avatar-size: 40px;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      box-sizing: border-box;
      text-align: center;
      overflow: hidden;
      color: var(--el-avatar-text-color);
      background: var(--el-avatar-bg-color);
      width: var(--el-avatar-size);
      height: var(--el-avatar-size);
      font-size: var(--el-avatar-text-size)
    }

    .el-avatar>img {
      display: block;
      width: 100%;
      height: 100%
    }

    .el-avatar--circle {
      border-radius: 50%
    }

    .el-avatar--square {
      border-radius: var(--el-avatar-border-radius)
    }

    .el-avatar--icon {
      font-size: var(--el-avatar-icon-size)
    }

    .el-avatar--small {
      --el-avatar-size: 24px
    }

    .el-avatar--large {
      --el-avatar-size: 56px
    }

    .el-backtop {
      --el-backtop-bg-color: var(--el-bg-color-overlay);
      --el-backtop-text-color: var(--el-color-primary);
      --el-backtop-hover-bg-color: var(--el-border-color-extra-light);
      position: fixed;
      background-color: var(--el-backtop-bg-color);
      width: 40px;
      height: 40px;
      border-radius: 50%;
      color: var(--el-backtop-text-color);
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 20px;
      box-shadow: var(--el-box-shadow-lighter);
      cursor: pointer;
      z-index: 5
    }

    .el-backtop:hover {
      background-color: var(--el-backtop-hover-bg-color)
    }

    .el-backtop__icon {
      font-size: 20px
    }

    .el-badge {
      --el-badge-bg-color: var(--el-color-danger);
      --el-badge-radius: 10px;
      --el-badge-font-size: 12px;
      --el-badge-padding: 6px;
      --el-badge-size: 18px;
      position: relative;
      vertical-align: middle;
      display: inline-block;
      width: -webkit-fit-content;
      width: -moz-fit-content;
      width: fit-content
    }

    .el-badge__content {
      background-color: var(--el-badge-bg-color);
      border-radius: var(--el-badge-radius);
      color: var(--el-color-white);
      display: inline-flex;
      justify-content: center;
      align-items: center;
      font-size: var(--el-badge-font-size);
      height: var(--el-badge-size);
      padding: 0 var(--el-badge-padding);
      white-space: nowrap;
      border: 1px solid var(--el-bg-color)
    }

    .el-badge__content.is-fixed {
      position: absolute;
      top: 0;
      right: calc(1px + var(--el-badge-size)/ 2);
      transform: translateY(-50%) translateX(100%);
      z-index: var(--el-index-normal)
    }

    .el-badge__content.is-fixed.is-dot {
      right: 5px
    }

    .el-badge__content.is-dot {
      height: 8px;
      width: 8px;
      padding: 0;
      right: 0;
      border-radius: 50%
    }

    .el-badge__content--primary {
      background-color: var(--el-color-primary)
    }

    .el-badge__content--success {
      background-color: var(--el-color-success)
    }

    .el-badge__content--warning {
      background-color: var(--el-color-warning)
    }

    .el-badge__content--info {
      background-color: var(--el-color-info)
    }

    .el-badge__content--danger {
      background-color: var(--el-color-danger)
    }

    .el-breadcrumb {
      font-size: 14px;
      line-height: 1
    }

    .el-breadcrumb::after,
    .el-breadcrumb::before {
      display: table;
      content: """"
    }

    .el-breadcrumb::after {
      clear: both
    }

    .el-breadcrumb__separator {
      margin: 0 9px;
      font-weight: 700;
      color: var(--el-text-color-placeholder)
    }

    .el-breadcrumb__separator.el-icon {
      margin: 0 6px;
      font-weight: 400
    }

    .el-breadcrumb__separator.el-icon svg {
      vertical-align: middle
    }

    .el-breadcrumb__item {
      float: left;
      display: inline-flex;
      align-items: center
    }

    .el-breadcrumb__inner {
      color: var(--el-text-color-regular)
    }

    .el-breadcrumb__inner a,
    .el-breadcrumb__inner.is-link {
      font-weight: 700;
      text-decoration: none;
      transition: var(--el-transition-color);
      color: var(--el-text-color-primary)
    }

    .el-breadcrumb__inner a:hover,
    .el-breadcrumb__inner.is-link:hover {
      color: var(--el-color-primary);
      cursor: pointer
    }

    .el-breadcrumb__item:last-child .el-breadcrumb__inner,
    .el-breadcrumb__item:last-child .el-breadcrumb__inner a,
    .el-breadcrumb__item:last-child .el-breadcrumb__inner a:hover,
    .el-breadcrumb__item:last-child .el-breadcrumb__inner:hover {
      font-weight: 400;
      color: var(--el-text-color-regular);
      cursor: text
    }

    .el-breadcrumb__item:last-child .el-breadcrumb__separator {
      display: none
    }

    .el-button-group {
      display: inline-block;
      vertical-align: middle
    }

    .el-button-group::after,
    .el-button-group::before {
      display: table;
      content: """"
    }

    .el-button-group::after {
      clear: both
    }

    .el-button-group>.el-button {
      float: left;
      position: relative
    }

    .el-button-group>.el-button+.el-button {
      margin-left: 0
    }

    .el-button-group>.el-button:first-child {
      border-top-right-radius: 0;
      border-bottom-right-radius: 0
    }

    .el-button-group>.el-button:last-child {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0
    }

    .el-button-group>.el-button:first-child:last-child {
      border-top-right-radius: var(--el-border-radius-base);
      border-bottom-right-radius: var(--el-border-radius-base);
      border-top-left-radius: var(--el-border-radius-base);
      border-bottom-left-radius: var(--el-border-radius-base)
    }

    .el-button-group>.el-button:first-child:last-child.is-round {
      border-radius: var(--el-border-radius-round)
    }

    .el-button-group>.el-button:first-child:last-child.is-circle {
      border-radius: 50%
    }

    .el-button-group>.el-button:not(:first-child):not(:last-child) {
      border-radius: 0
    }

    .el-button-group>.el-button:not(:last-child) {
      margin-right: -1px
    }

    .el-button-group>.el-button:active,
    .el-button-group>.el-button:focus,
    .el-button-group>.el-button:hover {
      z-index: 1
    }

    .el-button-group>.el-button.is-active {
      z-index: 1
    }

    .el-button-group>.el-dropdown>.el-button {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0;
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--primary:first-child {
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--primary:last-child {
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--primary:not(:first-child):not(:last-child) {
      border-left-color: var(--el-button-divide-border-color);
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--success:first-child {
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--success:last-child {
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--success:not(:first-child):not(:last-child) {
      border-left-color: var(--el-button-divide-border-color);
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--warning:first-child {
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--warning:last-child {
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--warning:not(:first-child):not(:last-child) {
      border-left-color: var(--el-button-divide-border-color);
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--danger:first-child {
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--danger:last-child {
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--danger:not(:first-child):not(:last-child) {
      border-left-color: var(--el-button-divide-border-color);
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--info:first-child {
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--info:last-child {
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--info:not(:first-child):not(:last-child) {
      border-left-color: var(--el-button-divide-border-color);
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button {
      --el-button-font-weight: var(--el-font-weight-primary);
      --el-button-border-color: var(--el-border-color);
      --el-button-bg-color: var(--el-fill-color-blank);
      --el-button-text-color: var(--el-text-color-regular);
      --el-button-disabled-text-color: var(--el-disabled-text-color);
      --el-button-disabled-bg-color: var(--el-fill-color-blank);
      --el-button-disabled-border-color: var(--el-border-color-light);
      --el-button-divide-border-color: rgba(255, 255, 255, 0.5);
      --el-button-hover-text-color: var(--el-color-primary);
      --el-button-hover-bg-color: var(--el-color-primary-light-9);
      --el-button-hover-border-color: var(--el-color-primary-light-7);
      --el-button-active-text-color: var(--el-button-hover-text-color);
      --el-button-active-border-color: var(--el-color-primary);
      --el-button-active-bg-color: var(--el-button-hover-bg-color);
      --el-button-outline-color: var(--el-color-primary-light-5);
      --el-button-hover-link-text-color: var(--el-color-info);
      --el-button-active-color: var(--el-text-color-primary)
    }

    .el-button {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      line-height: 1;
      height: 32px;
      white-space: nowrap;
      cursor: pointer;
      color: var(--el-button-text-color);
      text-align: center;
      box-sizing: border-box;
      outline: 0;
      transition: .1s;
      font-weight: var(--el-button-font-weight);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      vertical-align: middle;
      -webkit-appearance: none;
      background-color: var(--el-button-bg-color);
      border: var(--el-border);
      border-color: var(--el-button-border-color);
      padding: 8px 15px;
      font-size: var(--el-font-size-base);
      border-radius: var(--el-border-radius-base)
    }

    .el-button:focus,
    .el-button:hover {
      color: var(--el-button-hover-text-color);
      border-color: var(--el-button-hover-border-color);
      background-color: var(--el-button-hover-bg-color);
      outline: 0
    }

    .el-button:active {
      color: var(--el-button-active-text-color);
      border-color: var(--el-button-active-border-color);
      background-color: var(--el-button-active-bg-color);
      outline: 0
    }

    .el-button:focus-visible {
      outline: 2px solid var(--el-button-outline-color);
      outline-offset: 1px
    }

    .el-button>span {
      display: inline-flex;
      align-items: center
    }

    .el-button+.el-button {
      margin-left: 12px
    }

    .el-button.is-round {
      padding: 8px 15px
    }

    .el-button::-moz-focus-inner {
      border: 0
    }

    .el-button [class*=el-icon]+span {
      margin-left: 6px
    }

    .el-button [class*=el-icon] svg {
      vertical-align: bottom
    }

    .el-button.is-plain {
      --el-button-hover-text-color: var(--el-color-primary);
      --el-button-hover-bg-color: var(--el-fill-color-blank);
      --el-button-hover-border-color: var(--el-color-primary)
    }

    .el-button.is-active {
      color: var(--el-button-active-text-color);
      border-color: var(--el-button-active-border-color);
      background-color: var(--el-button-active-bg-color);
      outline: 0
    }

    .el-button.is-disabled,
    .el-button.is-disabled:focus,
    .el-button.is-disabled:hover {
      color: var(--el-button-disabled-text-color);
      cursor: not-allowed;
      background-image: none;
      background-color: var(--el-button-disabled-bg-color);
      border-color: var(--el-button-disabled-border-color)
    }

    .el-button.is-loading {
      position: relative;
      pointer-events: none
    }

    .el-button.is-loading:before {
      z-index: 1;
      pointer-events: none;
      content: """";
      position: absolute;
      left: -1px;
      top: -1px;
      right: -1px;
      bottom: -1px;
      border-radius: inherit;
      background-color: var(--el-mask-color-extra-light)
    }

    .el-button.is-round {
      border-radius: var(--el-border-radius-round)
    }

    .el-button.is-circle {
      width: 32px;
      border-radius: 50%;
      padding: 8px
    }

    .el-button.is-text {
      color: var(--el-button-text-color);
      border: 0 solid transparent;
      background-color: transparent
    }

    .el-button.is-text.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important
    }

    .el-button.is-text:not(.is-disabled):focus,
    .el-button.is-text:not(.is-disabled):hover {
      background-color: var(--el-fill-color-light)
    }

    .el-button.is-text:not(.is-disabled):focus-visible {
      outline: 2px solid var(--el-button-outline-color);
      outline-offset: 1px
    }

    .el-button.is-text:not(.is-disabled):active {
      background-color: var(--el-fill-color)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg {
      background-color: var(--el-fill-color-light)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg:focus,
    .el-button.is-text:not(.is-disabled).is-has-bg:hover {
      background-color: var(--el-fill-color)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg:active {
      background-color: var(--el-fill-color-dark)
    }

    .el-button__text--expand {
      letter-spacing: .3em;
      margin-right: -.3em
    }

    .el-button.is-link {
      border-color: transparent;
      color: var(--el-button-text-color);
      background: 0 0;
      padding: 2px;
      height: auto
    }

    .el-button.is-link:focus,
    .el-button.is-link:hover {
      color: var(--el-button-hover-link-text-color)
    }

    .el-button.is-link.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important;
      border-color: transparent !important
    }

    .el-button.is-link:not(.is-disabled):focus,
    .el-button.is-link:not(.is-disabled):hover {
      border-color: transparent;
      background-color: transparent
    }

    .el-button.is-link:not(.is-disabled):active {
      color: var(--el-button-active-color);
      border-color: transparent;
      background-color: transparent
    }

    .el-button--text {
      border-color: transparent;
      background: 0 0;
      color: var(--el-color-primary);
      padding-left: 0;
      padding-right: 0
    }

    .el-button--text.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important;
      border-color: transparent !important
    }

    .el-button--text:not(.is-disabled):focus,
    .el-button--text:not(.is-disabled):hover {
      color: var(--el-color-primary-light-3);
      border-color: transparent;
      background-color: transparent
    }

    .el-button--text:not(.is-disabled):active {
      color: var(--el-color-primary-dark-2);
      border-color: transparent;
      background-color: transparent
    }

    .el-button__link--expand {
      letter-spacing: .3em;
      margin-right: -.3em
    }

    .el-button--primary {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-primary);
      --el-button-border-color: var(--el-color-primary);
      --el-button-outline-color: var(--el-color-primary-light-5);
      --el-button-active-color: var(--el-color-primary-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-primary-light-5);
      --el-button-hover-bg-color: var(--el-color-primary-light-3);
      --el-button-hover-border-color: var(--el-color-primary-light-3);
      --el-button-active-bg-color: var(--el-color-primary-dark-2);
      --el-button-active-border-color: var(--el-color-primary-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-primary-light-5);
      --el-button-disabled-border-color: var(--el-color-primary-light-5)
    }

    .el-button--primary.is-link,
    .el-button--primary.is-plain,
    .el-button--primary.is-text {
      --el-button-text-color: var(--el-color-primary);
      --el-button-bg-color: var(--el-color-primary-light-9);
      --el-button-border-color: var(--el-color-primary-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-primary);
      --el-button-hover-border-color: var(--el-color-primary);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--primary.is-link.is-disabled,
    .el-button--primary.is-link.is-disabled:active,
    .el-button--primary.is-link.is-disabled:focus,
    .el-button--primary.is-link.is-disabled:hover,
    .el-button--primary.is-plain.is-disabled,
    .el-button--primary.is-plain.is-disabled:active,
    .el-button--primary.is-plain.is-disabled:focus,
    .el-button--primary.is-plain.is-disabled:hover,
    .el-button--primary.is-text.is-disabled,
    .el-button--primary.is-text.is-disabled:active,
    .el-button--primary.is-text.is-disabled:focus,
    .el-button--primary.is-text.is-disabled:hover {
      color: var(--el-color-primary-light-5);
      background-color: var(--el-color-primary-light-9);
      border-color: var(--el-color-primary-light-8)
    }

    .el-button--success {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-success);
      --el-button-border-color: var(--el-color-success);
      --el-button-outline-color: var(--el-color-success-light-5);
      --el-button-active-color: var(--el-color-success-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-success-light-5);
      --el-button-hover-bg-color: var(--el-color-success-light-3);
      --el-button-hover-border-color: var(--el-color-success-light-3);
      --el-button-active-bg-color: var(--el-color-success-dark-2);
      --el-button-active-border-color: var(--el-color-success-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-success-light-5);
      --el-button-disabled-border-color: var(--el-color-success-light-5)
    }

    .el-button--success.is-link,
    .el-button--success.is-plain,
    .el-button--success.is-text {
      --el-button-text-color: var(--el-color-success);
      --el-button-bg-color: var(--el-color-success-light-9);
      --el-button-border-color: var(--el-color-success-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-success);
      --el-button-hover-border-color: var(--el-color-success);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--success.is-link.is-disabled,
    .el-button--success.is-link.is-disabled:active,
    .el-button--success.is-link.is-disabled:focus,
    .el-button--success.is-link.is-disabled:hover,
    .el-button--success.is-plain.is-disabled,
    .el-button--success.is-plain.is-disabled:active,
    .el-button--success.is-plain.is-disabled:focus,
    .el-button--success.is-plain.is-disabled:hover,
    .el-button--success.is-text.is-disabled,
    .el-button--success.is-text.is-disabled:active,
    .el-button--success.is-text.is-disabled:focus,
    .el-button--success.is-text.is-disabled:hover {
      color: var(--el-color-success-light-5);
      background-color: var(--el-color-success-light-9);
      border-color: var(--el-color-success-light-8)
    }

    .el-button--warning {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-warning);
      --el-button-border-color: var(--el-color-warning);
      --el-button-outline-color: var(--el-color-warning-light-5);
      --el-button-active-color: var(--el-color-warning-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-warning-light-5);
      --el-button-hover-bg-color: var(--el-color-warning-light-3);
      --el-button-hover-border-color: var(--el-color-warning-light-3);
      --el-button-active-bg-color: var(--el-color-warning-dark-2);
      --el-button-active-border-color: var(--el-color-warning-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-warning-light-5);
      --el-button-disabled-border-color: var(--el-color-warning-light-5)
    }

    .el-button--warning.is-link,
    .el-button--warning.is-plain,
    .el-button--warning.is-text {
      --el-button-text-color: var(--el-color-warning);
      --el-button-bg-color: var(--el-color-warning-light-9);
      --el-button-border-color: var(--el-color-warning-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-warning);
      --el-button-hover-border-color: var(--el-color-warning);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--warning.is-link.is-disabled,
    .el-button--warning.is-link.is-disabled:active,
    .el-button--warning.is-link.is-disabled:focus,
    .el-button--warning.is-link.is-disabled:hover,
    .el-button--warning.is-plain.is-disabled,
    .el-button--warning.is-plain.is-disabled:active,
    .el-button--warning.is-plain.is-disabled:focus,
    .el-button--warning.is-plain.is-disabled:hover,
    .el-button--warning.is-text.is-disabled,
    .el-button--warning.is-text.is-disabled:active,
    .el-button--warning.is-text.is-disabled:focus,
    .el-button--warning.is-text.is-disabled:hover {
      color: var(--el-color-warning-light-5);
      background-color: var(--el-color-warning-light-9);
      border-color: var(--el-color-warning-light-8)
    }

    .el-button--danger {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-danger);
      --el-button-border-color: var(--el-color-danger);
      --el-button-outline-color: var(--el-color-danger-light-5);
      --el-button-active-color: var(--el-color-danger-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-danger-light-5);
      --el-button-hover-bg-color: var(--el-color-danger-light-3);
      --el-button-hover-border-color: var(--el-color-danger-light-3);
      --el-button-active-bg-color: var(--el-color-danger-dark-2);
      --el-button-active-border-color: var(--el-color-danger-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-danger-light-5);
      --el-button-disabled-border-color: var(--el-color-danger-light-5)
    }

    .el-button--danger.is-link,
    .el-button--danger.is-plain,
    .el-button--danger.is-text {
      --el-button-text-color: var(--el-color-danger);
      --el-button-bg-color: var(--el-color-danger-light-9);
      --el-button-border-color: var(--el-color-danger-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-danger);
      --el-button-hover-border-color: var(--el-color-danger);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--danger.is-link.is-disabled,
    .el-button--danger.is-link.is-disabled:active,
    .el-button--danger.is-link.is-disabled:focus,
    .el-button--danger.is-link.is-disabled:hover,
    .el-button--danger.is-plain.is-disabled,
    .el-button--danger.is-plain.is-disabled:active,
    .el-button--danger.is-plain.is-disabled:focus,
    .el-button--danger.is-plain.is-disabled:hover,
    .el-button--danger.is-text.is-disabled,
    .el-button--danger.is-text.is-disabled:active,
    .el-button--danger.is-text.is-disabled:focus,
    .el-button--danger.is-text.is-disabled:hover {
      color: var(--el-color-danger-light-5);
      background-color: var(--el-color-danger-light-9);
      border-color: var(--el-color-danger-light-8)
    }

    .el-button--info {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-info);
      --el-button-border-color: var(--el-color-info);
      --el-button-outline-color: var(--el-color-info-light-5);
      --el-button-active-color: var(--el-color-info-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-info-light-5);
      --el-button-hover-bg-color: var(--el-color-info-light-3);
      --el-button-hover-border-color: var(--el-color-info-light-3);
      --el-button-active-bg-color: var(--el-color-info-dark-2);
      --el-button-active-border-color: var(--el-color-info-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-info-light-5);
      --el-button-disabled-border-color: var(--el-color-info-light-5)
    }

    .el-button--info.is-link,
    .el-button--info.is-plain,
    .el-button--info.is-text {
      --el-button-text-color: var(--el-color-info);
      --el-button-bg-color: var(--el-color-info-light-9);
      --el-button-border-color: var(--el-color-info-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-info);
      --el-button-hover-border-color: var(--el-color-info);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--info.is-link.is-disabled,
    .el-button--info.is-link.is-disabled:active,
    .el-button--info.is-link.is-disabled:focus,
    .el-button--info.is-link.is-disabled:hover,
    .el-button--info.is-plain.is-disabled,
    .el-button--info.is-plain.is-disabled:active,
    .el-button--info.is-plain.is-disabled:focus,
    .el-button--info.is-plain.is-disabled:hover,
    .el-button--info.is-text.is-disabled,
    .el-button--info.is-text.is-disabled:active,
    .el-button--info.is-text.is-disabled:focus,
    .el-button--info.is-text.is-disabled:hover {
      color: var(--el-color-info-light-5);
      background-color: var(--el-color-info-light-9);
      border-color: var(--el-color-info-light-8)
    }

    .el-button--large {
      --el-button-size: 40px;
      height: var(--el-button-size);
      padding: 12px 19px;
      font-size: var(--el-font-size-base);
      border-radius: var(--el-border-radius-base)
    }

    .el-button--large [class*=el-icon]+span {
      margin-left: 8px
    }

    .el-button--large.is-round {
      padding: 12px 19px
    }

    .el-button--large.is-circle {
      width: var(--el-button-size);
      padding: 12px
    }

    .el-button--small {
      --el-button-size: 24px;
      height: var(--el-button-size);
      padding: 5px 11px;
      font-size: 12px;
      border-radius: calc(var(--el-border-radius-base) - 1px)
    }

    .el-button--small [class*=el-icon]+span {
      margin-left: 4px
    }

    .el-button--small.is-round {
      padding: 5px 11px
    }

    .el-button--small.is-circle {
      width: var(--el-button-size);
      padding: 5px
    }

    .el-calendar {
      --el-calendar-border: var(--el-table-border, 1px solid var(--el-border-color-lighter));
      --el-calendar-header-border-bottom: var(--el-calendar-border);
      --el-calendar-selected-bg-color: var(--el-color-primary-light-9);
      --el-calendar-cell-width: 85px;
      background-color: var(--el-fill-color-blank)
    }

    .el-calendar__header {
      display: flex;
      justify-content: space-between;
      padding: 12px 20px;
      border-bottom: var(--el-calendar-header-border-bottom)
    }

    .el-calendar__title {
      color: var(--el-text-color);
      align-self: center
    }

    .el-calendar__body {
      padding: 12px 20px 35px
    }

    .el-calendar-table {
      table-layout: fixed;
      width: 100%
    }

    .el-calendar-table thead th {
      padding: 12px 0;
      color: var(--el-text-color-regular);
      font-weight: 400
    }

    .el-calendar-table:not(.is-range) td.next,
    .el-calendar-table:not(.is-range) td.prev {
      color: var(--el-text-color-placeholder)
    }

    .el-calendar-table td {
      border-bottom: var(--el-calendar-border);
      border-right: var(--el-calendar-border);
      vertical-align: top;
      transition: background-color var(--el-transition-duration-fast) ease
    }

    .el-calendar-table td.is-selected {
      background-color: var(--el-calendar-selected-bg-color)
    }

    .el-calendar-table td.is-today {
      color: var(--el-color-primary)
    }

    .el-calendar-table tr:first-child td {
      border-top: var(--el-calendar-border)
    }

    .el-calendar-table tr td:first-child {
      border-left: var(--el-calendar-border)
    }

    .el-calendar-table tr.el-calendar-table__row--hide-border td {
      border-top: none
    }

    .el-calendar-table .el-calendar-day {
      box-sizing: border-box;
      padding: 8px;
      height: var(--el-calendar-cell-width)
    }

    .el-calendar-table .el-calendar-day:hover {
      cursor: pointer;
      background-color: var(--el-calendar-selected-bg-color)
    }

    .el-card {
      --el-card-border-color: var(--el-border-color-light);
      --el-card-border-radius: 4px;
      --el-card-padding: 20px;
      --el-card-bg-color: var(--el-fill-color-blank)
    }

    .el-card {
      border-radius: var(--el-card-border-radius);
      border: 1px solid var(--el-card-border-color);
      background-color: var(--el-card-bg-color);
      overflow: hidden;
      color: var(--el-text-color-primary);
      transition: var(--el-transition-duration)
    }

    .el-card.is-always-shadow {
      box-shadow: var(--el-box-shadow-light)
    }

    .el-card.is-hover-shadow:focus,
    .el-card.is-hover-shadow:hover {
      box-shadow: var(--el-box-shadow-light)
    }

    .el-card__header {
      padding: calc(var(--el-card-padding) - 2px) var(--el-card-padding);
      border-bottom: 1px solid var(--el-card-border-color);
      box-sizing: border-box
    }

    .el-card__body {
      padding: var(--el-card-padding)
    }

    .el-card__footer {
      padding: calc(var(--el-card-padding) - 2px) var(--el-card-padding);
      border-top: 1px solid var(--el-card-border-color);
      box-sizing: border-box
    }

    .el-carousel__item {
      position: absolute;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      display: inline-block;
      overflow: hidden;
      z-index: calc(var(--el-index-normal) - 1)
    }

    .el-carousel__item.is-active {
      z-index: calc(var(--el-index-normal) - 1)
    }

    .el-carousel__item.is-animating {
      transition: transform .4s ease-in-out
    }

    .el-carousel__item--card {
      width: 50%;
      transition: transform .4s ease-in-out
    }

    .el-carousel__item--card.is-in-stage {
      cursor: pointer;
      z-index: var(--el-index-normal)
    }

    .el-carousel__item--card.is-in-stage.is-hover .el-carousel__mask,
    .el-carousel__item--card.is-in-stage:hover .el-carousel__mask {
      opacity: .12
    }

    .el-carousel__item--card.is-active {
      z-index: calc(var(--el-index-normal) + 1)
    }

    .el-carousel__item--card-vertical {
      width: 100%;
      height: 50%
    }

    .el-carousel__mask {
      position: absolute;
      width: 100%;
      height: 100%;
      top: 0;
      left: 0;
      background-color: var(--el-color-white);
      opacity: .24;
      transition: var(--el-transition-duration-fast)
    }

    .el-carousel {
      --el-carousel-arrow-font-size: 12px;
      --el-carousel-arrow-size: 36px;
      --el-carousel-arrow-background: rgba(31, 45, 61, 0.11);
      --el-carousel-arrow-hover-background: rgba(31, 45, 61, 0.23);
      --el-carousel-indicator-width: 30px;
      --el-carousel-indicator-height: 2px;
      --el-carousel-indicator-padding-horizontal: 4px;
      --el-carousel-indicator-padding-vertical: 12px;
      --el-carousel-indicator-out-color: var(--el-border-color-hover);
      position: relative
    }

    .el-carousel--horizontal {
      overflow: hidden
    }

    .el-carousel--vertical {
      overflow: hidden
    }

    .el-carousel__container {
      position: relative;
      height: 300px
    }

    .el-carousel__arrow {
      border: none;
      outline: 0;
      padding: 0;
      margin: 0;
      height: var(--el-carousel-arrow-size);
      width: var(--el-carousel-arrow-size);
      cursor: pointer;
      transition: var(--el-transition-duration);
      border-radius: 50%;
      background-color: var(--el-carousel-arrow-background);
      color: #fff;
      position: absolute;
      top: 50%;
      z-index: 10;
      transform: translateY(-50%);
      text-align: center;
      font-size: var(--el-carousel-arrow-font-size);
      display: inline-flex;
      justify-content: center;
      align-items: center
    }

    .el-carousel__arrow--left {
      left: 16px
    }

    .el-carousel__arrow--right {
      right: 16px
    }

    .el-carousel__arrow:hover {
      background-color: var(--el-carousel-arrow-hover-background)
    }

    .el-carousel__arrow i {
      cursor: pointer
    }

    .el-carousel__indicators {
      position: absolute;
      list-style: none;
      margin: 0;
      padding: 0;
      z-index: calc(var(--el-index-normal) + 1)
    }

    .el-carousel__indicators--horizontal {
      bottom: 0;
      left: 50%;
      transform: translateX(-50%)
    }

    .el-carousel__indicators--vertical {
      right: 0;
      top: 50%;
      transform: translateY(-50%)
    }

    .el-carousel__indicators--outside {
      bottom: calc(var(--el-carousel-indicator-height) + var(--el-carousel-indicator-padding-vertical) * 2);
      text-align: center;
      position: static;
      transform: none
    }

    .el-carousel__indicators--outside .el-carousel__indicator:hover button {
      opacity: .64
    }

    .el-carousel__indicators--outside button {
      background-color: var(--el-carousel-indicator-out-color);
      opacity: .24
    }

    .el-carousel__indicators--right {
      right: 0
    }

    .el-carousel__indicators--labels {
      left: 0;
      right: 0;
      transform: none;
      text-align: center
    }

    .el-carousel__indicators--labels .el-carousel__button {
      height: auto;
      width: auto;
      padding: 2px 18px;
      font-size: 12px;
      color: #000
    }

    .el-carousel__indicators--labels .el-carousel__indicator {
      padding: 6px 4px
    }

    .el-carousel__indicator {
      background-color: transparent;
      cursor: pointer
    }

    .el-carousel__indicator:hover button {
      opacity: .72
    }

    .el-carousel__indicator--horizontal {
      display: inline-block;
      padding: var(--el-carousel-indicator-padding-vertical) var(--el-carousel-indicator-padding-horizontal)
    }

    .el-carousel__indicator--vertical {
      padding: var(--el-carousel-indicator-padding-horizontal) var(--el-carousel-indicator-padding-vertical)
    }

    .el-carousel__indicator--vertical .el-carousel__button {
      width: var(--el-carousel-indicator-height);
      height: calc(var(--el-carousel-indicator-width)/ 2)
    }

    .el-carousel__indicator.is-active button {
      opacity: 1
    }

    .el-carousel__button {
      display: block;
      opacity: .48;
      width: var(--el-carousel-indicator-width);
      height: var(--el-carousel-indicator-height);
      background-color: #fff;
      border: none;
      outline: 0;
      padding: 0;
      margin: 0;
      cursor: pointer;
      transition: var(--el-transition-duration)
    }

    .carousel-arrow-left-enter-from,
    .carousel-arrow-left-leave-active {
      transform: translateY(-50%) translateX(-10px);
      opacity: 0
    }

    .carousel-arrow-right-enter-from,
    .carousel-arrow-right-leave-active {
      transform: translateY(-50%) translateX(10px);
      opacity: 0
    }

    .el-cascader-panel {
      --el-cascader-menu-text-color: var(--el-text-color-regular);
      --el-cascader-menu-selected-text-color: var(--el-color-primary);
      --el-cascader-menu-fill: var(--el-bg-color-overlay);
      --el-cascader-menu-font-size: var(--el-font-size-base);
      --el-cascader-menu-radius: var(--el-border-radius-base);
      --el-cascader-menu-border: solid 1px var(--el-border-color-light);
      --el-cascader-menu-shadow: var(--el-box-shadow-light);
      --el-cascader-node-background-hover: var(--el-fill-color-light);
      --el-cascader-node-color-disabled: var(--el-text-color-placeholder);
      --el-cascader-color-empty: var(--el-text-color-placeholder);
      --el-cascader-tag-background: var(--el-fill-color)
    }

    .el-cascader-panel {
      display: flex;
      border-radius: var(--el-cascader-menu-radius);
      font-size: var(--el-cascader-menu-font-size)
    }

    .el-cascader-panel.is-bordered {
      border: var(--el-cascader-menu-border);
      border-radius: var(--el-cascader-menu-radius)
    }

    .el-cascader-menu {
      min-width: 180px;
      box-sizing: border-box;
      color: var(--el-cascader-menu-text-color);
      border-right: var(--el-cascader-menu-border)
    }

    .el-cascader-menu:last-child {
      border-right: none
    }

    .el-cascader-menu:last-child .el-cascader-node {
      padding-right: 20px
    }

    .el-cascader-menu__wrap.el-scrollbar__wrap {
      height: 204px
    }

    .el-cascader-menu__list {
      position: relative;
      min-height: 100%;
      margin: 0;
      padding: 6px 0;
      list-style: none;
      box-sizing: border-box
    }

    .el-cascader-menu__hover-zone {
      position: absolute;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      pointer-events: none
    }

    .el-cascader-menu__empty-text {
      position: absolute;
      top: 50%;
      left: 50%;
      transform: translate(-50%, -50%);
      display: flex;
      align-items: center;
      color: var(--el-cascader-color-empty)
    }

    .el-cascader-menu__empty-text .is-loading {
      margin-right: 2px
    }

    .el-cascader-node {
      position: relative;
      display: flex;
      align-items: center;
      padding: 0 30px 0 20px;
      height: 34px;
      line-height: 34px;
      outline: 0
    }

    .el-cascader-node.is-selectable.in-active-path {
      color: var(--el-cascader-menu-text-color)
    }

    .el-cascader-node.in-active-path,
    .el-cascader-node.is-active,
    .el-cascader-node.is-selectable.in-checked-path {
      color: var(--el-cascader-menu-selected-text-color);
      font-weight: 700
    }

    .el-cascader-node:not(.is-disabled) {
      cursor: pointer
    }

    .el-cascader-node:not(.is-disabled):focus,
    .el-cascader-node:not(.is-disabled):hover {
      background: var(--el-cascader-node-background-hover)
    }

    .el-cascader-node.is-disabled {
      color: var(--el-cascader-node-color-disabled);
      cursor: not-allowed
    }

    .el-cascader-node__prefix {
      position: absolute;
      left: 10px
    }

    .el-cascader-node__postfix {
      position: absolute;
      right: 10px
    }

    .el-cascader-node__label {
      flex: 1;
      text-align: left;
      padding: 0 8px;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis
    }

    .el-cascader-node>.el-checkbox {
      margin-right: 0
    }

    .el-cascader-node>.el-radio {
      margin-right: 0
    }

    .el-cascader-node>.el-radio .el-radio__label {
      padding-left: 0
    }

    .el-cascader {
      --el-cascader-menu-text-color: var(--el-text-color-regular);
      --el-cascader-menu-selected-text-color: var(--el-color-primary);
      --el-cascader-menu-fill: var(--el-bg-color-overlay);
      --el-cascader-menu-font-size: var(--el-font-size-base);
      --el-cascader-menu-radius: var(--el-border-radius-base);
      --el-cascader-menu-border: solid 1px var(--el-border-color-light);
      --el-cascader-menu-shadow: var(--el-box-shadow-light);
      --el-cascader-node-background-hover: var(--el-fill-color-light);
      --el-cascader-node-color-disabled: var(--el-text-color-placeholder);
      --el-cascader-color-empty: var(--el-text-color-placeholder);
      --el-cascader-tag-background: var(--el-fill-color);
      display: inline-block;
      vertical-align: middle;
      position: relative;
      font-size: var(--el-font-size-base);
      line-height: 32px;
      outline: 0
    }

    .el-cascader:not(.is-disabled):hover .el-input__wrapper {
      cursor: pointer;
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-cascader .el-input {
      display: flex;
      cursor: pointer
    }

    .el-cascader .el-input .el-input__inner {
      text-overflow: ellipsis;
      cursor: pointer
    }

    .el-cascader .el-input .el-input__suffix-inner .el-icon {
      height: calc(100% - 2px)
    }

    .el-cascader .el-input .el-input__suffix-inner .el-icon svg {
      vertical-align: middle
    }

    .el-cascader .el-input .icon-arrow-down {
      transition: transform var(--el-transition-duration);
      font-size: 14px
    }

    .el-cascader .el-input .icon-arrow-down.is-reverse {
      transform: rotateZ(180deg)
    }

    .el-cascader .el-input .icon-circle-close:hover {
      color: var(--el-input-clear-hover-color, var(--el-text-color-secondary))
    }

    .el-cascader .el-input.is-focus .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color, var(--el-color-primary)) inset
    }

    .el-cascader--large {
      font-size: 14px;
      line-height: 40px
    }

    .el-cascader--small {
      font-size: 12px;
      line-height: 24px
    }

    .el-cascader.is-disabled .el-cascader__label {
      z-index: calc(var(--el-index-normal) + 1);
      color: var(--el-disabled-text-color)
    }

    .el-cascader__dropdown {
      --el-cascader-menu-text-color: var(--el-text-color-regular);
      --el-cascader-menu-selected-text-color: var(--el-color-primary);
      --el-cascader-menu-fill: var(--el-bg-color-overlay);
      --el-cascader-menu-font-size: var(--el-font-size-base);
      --el-cascader-menu-radius: var(--el-border-radius-base);
      --el-cascader-menu-border: solid 1px var(--el-border-color-light);
      --el-cascader-menu-shadow: var(--el-box-shadow-light);
      --el-cascader-node-background-hover: var(--el-fill-color-light);
      --el-cascader-node-color-disabled: var(--el-text-color-placeholder);
      --el-cascader-color-empty: var(--el-text-color-placeholder);
      --el-cascader-tag-background: var(--el-fill-color)
    }

    .el-cascader__dropdown {
      font-size: var(--el-cascader-menu-font-size);
      border-radius: var(--el-cascader-menu-radius)
    }

    .el-cascader__dropdown.el-popper {
      background: var(--el-cascader-menu-fill);
      border: var(--el-cascader-menu-border);
      box-shadow: var(--el-cascader-menu-shadow)
    }

    .el-cascader__dropdown.el-popper .el-popper__arrow::before {
      border: var(--el-cascader-menu-border)
    }

    .el-cascader__dropdown.el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-cascader__dropdown.el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-cascader__dropdown.el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-cascader__dropdown.el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-cascader__dropdown.el-popper {
      box-shadow: var(--el-cascader-menu-shadow)
    }

    .el-cascader__tags {
      position: absolute;
      left: 0;
      right: 30px;
      top: 50%;
      transform: translateY(-50%);
      display: flex;
      flex-wrap: wrap;
      line-height: normal;
      text-align: left;
      box-sizing: border-box
    }

    .el-cascader__tags .el-tag {
      display: inline-flex;
      align-items: center;
      max-width: 100%;
      margin: 2px 0 2px 6px;
      text-overflow: ellipsis;
      background: var(--el-cascader-tag-background)
    }

    .el-cascader__tags .el-tag:not(.is-hit) {
      border-color: transparent
    }

    .el-cascader__tags .el-tag>span {
      flex: 1;
      overflow: hidden;
      text-overflow: ellipsis
    }

    .el-cascader__tags .el-tag .el-icon-close {
      flex: none;
      background-color: var(--el-text-color-placeholder);
      color: var(--el-color-white)
    }

    .el-cascader__tags .el-tag .el-icon-close:hover {
      background-color: var(--el-text-color-secondary)
    }

    .el-cascader__collapse-tags {
      white-space: normal;
      z-index: var(--el-index-normal)
    }

    .el-cascader__collapse-tags .el-tag {
      display: inline-flex;
      align-items: center;
      max-width: 100%;
      margin: 2px 0 2px 6px;
      text-overflow: ellipsis;
      background: var(--el-fill-color)
    }

    .el-cascader__collapse-tags .el-tag:not(.is-hit) {
      border-color: transparent
    }

    .el-cascader__collapse-tags .el-tag>span {
      flex: 1;
      overflow: hidden;
      text-overflow: ellipsis
    }

    .el-cascader__collapse-tags .el-tag .el-icon-close {
      flex: none;
      background-color: var(--el-text-color-placeholder);
      color: var(--el-color-white)
    }

    .el-cascader__collapse-tags .el-tag .el-icon-close:hover {
      background-color: var(--el-text-color-secondary)
    }

    .el-cascader__suggestion-panel {
      border-radius: var(--el-cascader-menu-radius)
    }

    .el-cascader__suggestion-list {
      max-height: 204px;
      margin: 0;
      padding: 6px 0;
      font-size: var(--el-font-size-base);
      color: var(--el-cascader-menu-text-color);
      text-align: center
    }

    .el-cascader__suggestion-item {
      display: flex;
      justify-content: space-between;
      align-items: center;
      height: 34px;
      padding: 0 15px;
      text-align: left;
      outline: 0;
      cursor: pointer
    }

    .el-cascader__suggestion-item:focus,
    .el-cascader__suggestion-item:hover {
      background: var(--el-cascader-node-background-hover)
    }

    .el-cascader__suggestion-item.is-checked {
      color: var(--el-cascader-menu-selected-text-color);
      font-weight: 700
    }

    .el-cascader__suggestion-item>span {
      margin-right: 10px
    }

    .el-cascader__empty-text {
      margin: 10px 0;
      color: var(--el-cascader-color-empty)
    }

    .el-cascader__search-input {
      flex: 1;
      height: 24px;
      min-width: 60px;
      margin: 2px 0 2px 11px;
      padding: 0;
      color: var(--el-cascader-menu-text-color);
      border: none;
      outline: 0;
      box-sizing: border-box;
      background: 0 0
    }

    .el-cascader__search-input::-moz-placeholder {
      color: transparent
    }

    .el-cascader__search-input:-ms-input-placeholder {
      color: transparent
    }

    .el-cascader__search-input::placeholder {
      color: transparent
    }

    .el-check-tag {
      background-color: var(--el-color-info-light-9);
      border-radius: var(--el-border-radius-base);
      color: var(--el-color-info);
      cursor: pointer;
      display: inline-block;
      font-size: var(--el-font-size-base);
      line-height: var(--el-font-size-base);
      padding: 7px 15px;
      transition: var(--el-transition-all);
      font-weight: 700
    }

    .el-check-tag:hover {
      background-color: var(--el-color-info-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--primary {
      background-color: var(--el-color-primary-light-8);
      color: var(--el-color-primary)
    }

    .el-check-tag.is-checked.el-check-tag--primary:hover {
      background-color: var(--el-color-primary-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--success {
      background-color: var(--el-color-success-light-8);
      color: var(--el-color-success)
    }

    .el-check-tag.is-checked.el-check-tag--success:hover {
      background-color: var(--el-color-success-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--warning {
      background-color: var(--el-color-warning-light-8);
      color: var(--el-color-warning)
    }

    .el-check-tag.is-checked.el-check-tag--warning:hover {
      background-color: var(--el-color-warning-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--danger {
      background-color: var(--el-color-danger-light-8);
      color: var(--el-color-danger)
    }

    .el-check-tag.is-checked.el-check-tag--danger:hover {
      background-color: var(--el-color-danger-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--error {
      background-color: var(--el-color-error-light-8);
      color: var(--el-color-error)
    }

    .el-check-tag.is-checked.el-check-tag--error:hover {
      background-color: var(--el-color-error-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--info {
      background-color: var(--el-color-info-light-8);
      color: var(--el-color-info)
    }

    .el-check-tag.is-checked.el-check-tag--info:hover {
      background-color: var(--el-color-info-light-7)
    }

    .el-checkbox-button {
      --el-checkbox-button-checked-bg-color: var(--el-color-primary);
      --el-checkbox-button-checked-text-color: var(--el-color-white);
      --el-checkbox-button-checked-border-color: var(--el-color-primary)
    }

    .el-checkbox-button {
      position: relative;
      display: inline-block
    }

    .el-checkbox-button__inner {
      display: inline-block;
      line-height: 1;
      font-weight: var(--el-checkbox-font-weight);
      white-space: nowrap;
      vertical-align: middle;
      cursor: pointer;
      background: var(--el-button-bg-color, var(--el-fill-color-blank));
      border: var(--el-border);
      border-left-color: transparent;
      color: var(--el-button-text-color, var(--el-text-color-regular));
      -webkit-appearance: none;
      text-align: center;
      box-sizing: border-box;
      outline: 0;
      margin: 0;
      position: relative;
      transition: var(--el-transition-all);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      padding: 8px 15px;
      font-size: var(--el-font-size-base);
      border-radius: 0
    }

    .el-checkbox-button__inner.is-round {
      padding: 8px 15px
    }

    .el-checkbox-button__inner:hover {
      color: var(--el-color-primary)
    }

    .el-checkbox-button__inner [class*=el-icon-] {
      line-height: .9
    }

    .el-checkbox-button__inner [class*=el-icon-]+span {
      margin-left: 5px
    }

    .el-checkbox-button__original {
      opacity: 0;
      outline: 0;
      position: absolute;
      margin: 0;
      z-index: -1
    }

    .el-checkbox-button.is-checked .el-checkbox-button__inner {
      color: var(--el-checkbox-button-checked-text-color);
      background-color: var(--el-checkbox-button-checked-bg-color);
      border-color: var(--el-checkbox-button-checked-border-color);
      box-shadow: -1px 0 0 0 var(--el-color-primary-light-7)
    }

    .el-checkbox-button.is-checked:first-child .el-checkbox-button__inner {
      border-left-color: var(--el-checkbox-button-checked-border-color)
    }

    .el-checkbox-button.is-disabled .el-checkbox-button__inner {
      color: var(--el-disabled-text-color);
      cursor: not-allowed;
      background-image: none;
      background-color: var(--el-button-disabled-bg-color, var(--el-fill-color-blank));
      border-color: var(--el-button-disabled-border-color, var(--el-border-color-light));
      box-shadow: none
    }

    .el-checkbox-button.is-disabled:first-child .el-checkbox-button__inner {
      border-left-color: var(--el-button-disabled-border-color, var(--el-border-color-light))
    }

    .el-checkbox-button:first-child .el-checkbox-button__inner {
      border-left: var(--el-border);
      border-top-left-radius: var(--el-border-radius-base);
      border-bottom-left-radius: var(--el-border-radius-base);
      box-shadow: none !important
    }

    .el-checkbox-button.is-focus .el-checkbox-button__inner {
      border-color: var(--el-checkbox-button-checked-border-color)
    }

    .el-checkbox-button:last-child .el-checkbox-button__inner {
      border-top-right-radius: var(--el-border-radius-base);
      border-bottom-right-radius: var(--el-border-radius-base)
    }

    .el-checkbox-button--large .el-checkbox-button__inner {
      padding: 12px 19px;
      font-size: var(--el-font-size-base);
      border-radius: 0
    }

    .el-checkbox-button--large .el-checkbox-button__inner.is-round {
      padding: 12px 19px
    }

    .el-checkbox-button--small .el-checkbox-button__inner {
      padding: 5px 11px;
      font-size: 12px;
      border-radius: 0
    }

    .el-checkbox-button--small .el-checkbox-button__inner.is-round {
      padding: 5px 11px
    }

    .el-checkbox-group {
      font-size: 0;
      line-height: 0
    }

    .el-checkbox {
      --el-checkbox-font-size: 14px;
      --el-checkbox-font-weight: var(--el-font-weight-primary);
      --el-checkbox-text-color: var(--el-text-color-regular);
      --el-checkbox-input-height: 14px;
      --el-checkbox-input-width: 14px;
      --el-checkbox-border-radius: var(--el-border-radius-small);
      --el-checkbox-bg-color: var(--el-fill-color-blank);
      --el-checkbox-input-border: var(--el-border);
      --el-checkbox-disabled-border-color: var(--el-border-color);
      --el-checkbox-disabled-input-fill: var(--el-fill-color-light);
      --el-checkbox-disabled-icon-color: var(--el-text-color-placeholder);
      --el-checkbox-disabled-checked-input-fill: var(--el-border-color-extra-light);
      --el-checkbox-disabled-checked-input-border-color: var(--el-border-color);
      --el-checkbox-disabled-checked-icon-color: var(--el-text-color-placeholder);
      --el-checkbox-checked-text-color: var(--el-color-primary);
      --el-checkbox-checked-input-border-color: var(--el-color-primary);
      --el-checkbox-checked-bg-color: var(--el-color-primary);
      --el-checkbox-checked-icon-color: var(--el-color-white);
      --el-checkbox-input-border-color-hover: var(--el-color-primary)
    }

    .el-checkbox {
      color: var(--el-checkbox-text-color);
      font-weight: var(--el-checkbox-font-weight);
      font-size: var(--el-font-size-base);
      position: relative;
      cursor: pointer;
      display: inline-flex;
      align-items: center;
      white-space: nowrap;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      margin-right: 30px;
      height: var(--el-checkbox-height, 32px)
    }

    .el-checkbox.is-disabled {
      cursor: not-allowed
    }

    .el-checkbox.is-bordered {
      padding: 0 15px 0 9px;
      border-radius: var(--el-border-radius-base);
      border: var(--el-border);
      box-sizing: border-box
    }

    .el-checkbox.is-bordered.is-checked {
      border-color: var(--el-color-primary)
    }

    .el-checkbox.is-bordered.is-disabled {
      border-color: var(--el-border-color-lighter)
    }

    .el-checkbox.is-bordered.el-checkbox--large {
      padding: 0 19px 0 11px;
      border-radius: var(--el-border-radius-base)
    }

    .el-checkbox.is-bordered.el-checkbox--large .el-checkbox__label {
      font-size: var(--el-font-size-base)
    }

    .el-checkbox.is-bordered.el-checkbox--large .el-checkbox__inner {
      height: 14px;
      width: 14px
    }

    .el-checkbox.is-bordered.el-checkbox--small {
      padding: 0 11px 0 7px;
      border-radius: calc(var(--el-border-radius-base) - 1px)
    }

    .el-checkbox.is-bordered.el-checkbox--small .el-checkbox__label {
      font-size: 12px
    }

    .el-checkbox.is-bordered.el-checkbox--small .el-checkbox__inner {
      height: 12px;
      width: 12px
    }

    .el-checkbox.is-bordered.el-checkbox--small .el-checkbox__inner::after {
      height: 6px;
      width: 2px
    }

    .el-checkbox input:focus-visible+.el-checkbox__inner {
      outline: 2px solid var(--el-checkbox-input-border-color-hover);
      outline-offset: 1px;
      border-radius: var(--el-checkbox-border-radius)
    }

    .el-checkbox__input {
      white-space: nowrap;
      cursor: pointer;
      outline: 0;
      display: inline-flex;
      position: relative
    }

    .el-checkbox__input.is-disabled .el-checkbox__inner {
      background-color: var(--el-checkbox-disabled-input-fill);
      border-color: var(--el-checkbox-disabled-border-color);
      cursor: not-allowed
    }

    .el-checkbox__input.is-disabled .el-checkbox__inner::after {
      cursor: not-allowed;
      border-color: var(--el-checkbox-disabled-icon-color)
    }

    .el-checkbox__input.is-disabled.is-checked .el-checkbox__inner {
      background-color: var(--el-checkbox-disabled-checked-input-fill);
      border-color: var(--el-checkbox-disabled-checked-input-border-color)
    }

    .el-checkbox__input.is-disabled.is-checked .el-checkbox__inner::after {
      border-color: var(--el-checkbox-disabled-checked-icon-color)
    }

    .el-checkbox__input.is-disabled.is-indeterminate .el-checkbox__inner {
      background-color: var(--el-checkbox-disabled-checked-input-fill);
      border-color: var(--el-checkbox-disabled-checked-input-border-color)
    }

    .el-checkbox__input.is-disabled.is-indeterminate .el-checkbox__inner::before {
      background-color: var(--el-checkbox-disabled-checked-icon-color);
      border-color: var(--el-checkbox-disabled-checked-icon-color)
    }

    .el-checkbox__input.is-disabled+span.el-checkbox__label {
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-checkbox__input.is-checked .el-checkbox__inner {
      background-color: var(--el-checkbox-checked-bg-color);
      border-color: var(--el-checkbox-checked-input-border-color)
    }

    .el-checkbox__input.is-checked .el-checkbox__inner::after {
      transform: rotate(45deg) scaleY(1);
      border-color: var(--el-checkbox-checked-icon-color)
    }

    .el-checkbox__input.is-checked+.el-checkbox__label {
      color: var(--el-checkbox-checked-text-color)
    }

    .el-checkbox__input.is-focus:not(.is-checked) .el-checkbox__original:not(:focus-visible) {
      border-color: var(--el-checkbox-input-border-color-hover)
    }

    .el-checkbox__input.is-indeterminate .el-checkbox__inner {
      background-color: var(--el-checkbox-checked-bg-color);
      border-color: var(--el-checkbox-checked-input-border-color)
    }

    .el-checkbox__input.is-indeterminate .el-checkbox__inner::before {
      content: """";
      position: absolute;
      display: block;
      background-color: var(--el-checkbox-checked-icon-color);
      height: 2px;
      transform: scale(.5);
      left: 0;
      right: 0;
      top: 5px
    }

    .el-checkbox__input.is-indeterminate .el-checkbox__inner::after {
      display: none
    }

    .el-checkbox__inner {
      display: inline-block;
      position: relative;
      border: var(--el-checkbox-input-border);
      border-radius: var(--el-checkbox-border-radius);
      box-sizing: border-box;
      width: var(--el-checkbox-input-width);
      height: var(--el-checkbox-input-height);
      background-color: var(--el-checkbox-bg-color);
      z-index: var(--el-index-normal);
      transition: border-color .25s cubic-bezier(.71, -.46, .29, 1.46), background-color .25s cubic-bezier(.71, -.46, .29, 1.46), outline .25s cubic-bezier(.71, -.46, .29, 1.46)
    }

    .el-checkbox__inner:hover {
      border-color: var(--el-checkbox-input-border-color-hover)
    }

    .el-checkbox__inner::after {
      box-sizing: content-box;
      content: """";
      border: 1px solid transparent;
      border-left: 0;
      border-top: 0;
      height: 7px;
      left: 4px;
      position: absolute;
      top: 1px;
      transform: rotate(45deg) scaleY(0);
      width: 3px;
      transition: transform .15s ease-in 50ms;
      transform-origin: center
    }

    .el-checkbox__original {
      opacity: 0;
      outline: 0;
      position: absolute;
      margin: 0;
      width: 0;
      height: 0;
      z-index: -1
    }

    .el-checkbox__label {
      display: inline-block;
      padding-left: 8px;
      line-height: 1;
      font-size: var(--el-checkbox-font-size)
    }

    .el-checkbox.el-checkbox--large {
      height: 40px
    }

    .el-checkbox.el-checkbox--large .el-checkbox__label {
      font-size: 14px
    }

    .el-checkbox.el-checkbox--large .el-checkbox__inner {
      width: 14px;
      height: 14px
    }

    .el-checkbox.el-checkbox--small {
      height: 24px
    }

    .el-checkbox.el-checkbox--small .el-checkbox__label {
      font-size: 12px
    }

    .el-checkbox.el-checkbox--small .el-checkbox__inner {
      width: 12px;
      height: 12px
    }

    .el-checkbox.el-checkbox--small .el-checkbox__input.is-indeterminate .el-checkbox__inner::before {
      top: 4px
    }

    .el-checkbox.el-checkbox--small .el-checkbox__inner::after {
      width: 2px;
      height: 6px
    }

    .el-checkbox:last-of-type {
      margin-right: 0
    }

    [class*=el-col-] {
      box-sizing: border-box
    }

    [class*=el-col-].is-guttered {
      display: block;
      min-height: 1px
    }

    .el-col-0 {
      display: none
    }

    .el-col-0.is-guttered {
      display: none
    }

    .el-col-0 {
      max-width: 0%;
      flex: 0 0 0%
    }

    .el-col-offset-0 {
      margin-left: 0
    }

    .el-col-pull-0 {
      position: relative;
      right: 0
    }

    .el-col-push-0 {
      position: relative;
      left: 0
    }

    .el-col-1 {
      max-width: 4.1666666667%;
      flex: 0 0 4.1666666667%
    }

    .el-col-offset-1 {
      margin-left: 4.1666666667%
    }

    .el-col-pull-1 {
      position: relative;
      right: 4.1666666667%
    }

    .el-col-push-1 {
      position: relative;
      left: 4.1666666667%
    }

    .el-col-2 {
      max-width: 8.3333333333%;
      flex: 0 0 8.3333333333%
    }

    .el-col-offset-2 {
      margin-left: 8.3333333333%
    }

    .el-col-pull-2 {
      position: relative;
      right: 8.3333333333%
    }

    .el-col-push-2 {
      position: relative;
      left: 8.3333333333%
    }

    .el-col-3 {
      max-width: 12.5%;
      flex: 0 0 12.5%
    }

    .el-col-offset-3 {
      margin-left: 12.5%
    }

    .el-col-pull-3 {
      position: relative;
      right: 12.5%
    }

    .el-col-push-3 {
      position: relative;
      left: 12.5%
    }

    .el-col-4 {
      max-width: 16.6666666667%;
      flex: 0 0 16.6666666667%
    }

    .el-col-offset-4 {
      margin-left: 16.6666666667%
    }

    .el-col-pull-4 {
      position: relative;
      right: 16.6666666667%
    }

    .el-col-push-4 {
      position: relative;
      left: 16.6666666667%
    }

    .el-col-5 {
      max-width: 20.8333333333%;
      flex: 0 0 20.8333333333%
    }

    .el-col-offset-5 {
      margin-left: 20.8333333333%
    }

    .el-col-pull-5 {
      position: relative;
      right: 20.8333333333%
    }

    .el-col-push-5 {
      position: relative;
      left: 20.8333333333%
    }

    .el-col-6 {
      max-width: 25%;
      flex: 0 0 25%
    }

    .el-col-offset-6 {
      margin-left: 25%
    }

    .el-col-pull-6 {
      position: relative;
      right: 25%
    }

    .el-col-push-6 {
      position: relative;
      left: 25%
    }

    .el-col-7 {
      max-width: 29.1666666667%;
      flex: 0 0 29.1666666667%
    }

    .el-col-offset-7 {
      margin-left: 29.1666666667%
    }

    .el-col-pull-7 {
      position: relative;
      right: 29.1666666667%
    }

    .el-col-push-7 {
      position: relative;
      left: 29.1666666667%
    }

    .el-col-8 {
      max-width: 33.3333333333%;
      flex: 0 0 33.3333333333%
    }

    .el-col-offset-8 {
      margin-left: 33.3333333333%
    }

    .el-col-pull-8 {
      position: relative;
      right: 33.3333333333%
    }

    .el-col-push-8 {
      position: relative;
      left: 33.3333333333%
    }

    .el-col-9 {
      max-width: 37.5%;
      flex: 0 0 37.5%
    }

    .el-col-offset-9 {
      margin-left: 37.5%
    }

    .el-col-pull-9 {
      position: relative;
      right: 37.5%
    }

    .el-col-push-9 {
      position: relative;
      left: 37.5%
    }

    .el-col-10 {
      max-width: 41.6666666667%;
      flex: 0 0 41.6666666667%
    }

    .el-col-offset-10 {
      margin-left: 41.6666666667%
    }

    .el-col-pull-10 {
      position: relative;
      right: 41.6666666667%
    }

    .el-col-push-10 {
      position: relative;
      left: 41.6666666667%
    }

    .el-col-11 {
      max-width: 45.8333333333%;
      flex: 0 0 45.8333333333%
    }

    .el-col-offset-11 {
      margin-left: 45.8333333333%
    }

    .el-col-pull-11 {
      position: relative;
      right: 45.8333333333%
    }

    .el-col-push-11 {
      position: relative;
      left: 45.8333333333%
    }

    .el-col-12 {
      max-width: 50%;
      flex: 0 0 50%
    }

    .el-col-offset-12 {
      margin-left: 50%
    }

    .el-col-pull-12 {
      position: relative;
      right: 50%
    }

    .el-col-push-12 {
      position: relative;
      left: 50%
    }

    .el-col-13 {
      max-width: 54.1666666667%;
      flex: 0 0 54.1666666667%
    }

    .el-col-offset-13 {
      margin-left: 54.1666666667%
    }

    .el-col-pull-13 {
      position: relative;
      right: 54.1666666667%
    }

    .el-col-push-13 {
      position: relative;
      left: 54.1666666667%
    }

    .el-col-14 {
      max-width: 58.3333333333%;
      flex: 0 0 58.3333333333%
    }

    .el-col-offset-14 {
      margin-left: 58.3333333333%
    }

    .el-col-pull-14 {
      position: relative;
      right: 58.3333333333%
    }

    .el-col-push-14 {
      position: relative;
      left: 58.3333333333%
    }

    .el-col-15 {
      max-width: 62.5%;
      flex: 0 0 62.5%
    }

    .el-col-offset-15 {
      margin-left: 62.5%
    }

    .el-col-pull-15 {
      position: relative;
      right: 62.5%
    }

    .el-col-push-15 {
      position: relative;
      left: 62.5%
    }

    .el-col-16 {
      max-width: 66.6666666667%;
      flex: 0 0 66.6666666667%
    }

    .el-col-offset-16 {
      margin-left: 66.6666666667%
    }

    .el-col-pull-16 {
      position: relative;
      right: 66.6666666667%
    }

    .el-col-push-16 {
      position: relative;
      left: 66.6666666667%
    }

    .el-col-17 {
      max-width: 70.8333333333%;
      flex: 0 0 70.8333333333%
    }

    .el-col-offset-17 {
      margin-left: 70.8333333333%
    }

    .el-col-pull-17 {
      position: relative;
      right: 70.8333333333%
    }

    .el-col-push-17 {
      position: relative;
      left: 70.8333333333%
    }

    .el-col-18 {
      max-width: 75%;
      flex: 0 0 75%
    }

    .el-col-offset-18 {
      margin-left: 75%
    }

    .el-col-pull-18 {
      position: relative;
      right: 75%
    }

    .el-col-push-18 {
      position: relative;
      left: 75%
    }

    .el-col-19 {
      max-width: 79.1666666667%;
      flex: 0 0 79.1666666667%
    }

    .el-col-offset-19 {
      margin-left: 79.1666666667%
    }

    .el-col-pull-19 {
      position: relative;
      right: 79.1666666667%
    }

    .el-col-push-19 {
      position: relative;
      left: 79.1666666667%
    }

    .el-col-20 {
      max-width: 83.3333333333%;
      flex: 0 0 83.3333333333%
    }

    .el-col-offset-20 {
      margin-left: 83.3333333333%
    }

    .el-col-pull-20 {
      position: relative;
      right: 83.3333333333%
    }

    .el-col-push-20 {
      position: relative;
      left: 83.3333333333%
    }

    .el-col-21 {
      max-width: 87.5%;
      flex: 0 0 87.5%
    }

    .el-col-offset-21 {
      margin-left: 87.5%
    }

    .el-col-pull-21 {
      position: relative;
      right: 87.5%
    }

    .el-col-push-21 {
      position: relative;
      left: 87.5%
    }

    .el-col-22 {
      max-width: 91.6666666667%;
      flex: 0 0 91.6666666667%
    }

    .el-col-offset-22 {
      margin-left: 91.6666666667%
    }

    .el-col-pull-22 {
      position: relative;
      right: 91.6666666667%
    }

    .el-col-push-22 {
      position: relative;
      left: 91.6666666667%
    }

    .el-col-23 {
      max-width: 95.8333333333%;
      flex: 0 0 95.8333333333%
    }

    .el-col-offset-23 {
      margin-left: 95.8333333333%
    }

    .el-col-pull-23 {
      position: relative;
      right: 95.8333333333%
    }

    .el-col-push-23 {
      position: relative;
      left: 95.8333333333%
    }

    .el-col-24 {
      max-width: 100%;
      flex: 0 0 100%
    }

    .el-col-offset-24 {
      margin-left: 100%
    }

    .el-col-pull-24 {
      position: relative;
      right: 100%
    }

    .el-col-push-24 {
      position: relative;
      left: 100%
    }

    @media only screen and (max-width:767px) {
      .el-col-xs-0 {
        display: none
      }

      .el-col-xs-0.is-guttered {
        display: none
      }

      .el-col-xs-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-xs-offset-0 {
        margin-left: 0
      }

      .el-col-xs-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-xs-push-0 {
        position: relative;
        left: 0
      }

      .el-col-xs-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-xs-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-xs-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-xs-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-xs-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-xs-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-xs-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-xs-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-xs-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-xs-offset-3 {
        margin-left: 12.5%
      }

      .el-col-xs-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-xs-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-xs-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-xs-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-xs-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-xs-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-xs-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-xs-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-xs-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-xs-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-xs-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-xs-offset-6 {
        margin-left: 25%
      }

      .el-col-xs-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-xs-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-xs-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-xs-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-xs-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-xs-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-xs-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-xs-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-xs-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-xs-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-xs-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-xs-offset-9 {
        margin-left: 37.5%
      }

      .el-col-xs-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-xs-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-xs-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-xs-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-xs-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-xs-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-xs-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-xs-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-xs-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-xs-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-xs-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-xs-offset-12 {
        margin-left: 50%
      }

      .el-col-xs-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-xs-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-xs-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-xs-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-xs-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-xs-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-xs-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-xs-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-xs-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-xs-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-xs-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-xs-offset-15 {
        margin-left: 62.5%
      }

      .el-col-xs-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-xs-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-xs-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-xs-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-xs-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-xs-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-xs-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-xs-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-xs-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-xs-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-xs-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-xs-offset-18 {
        margin-left: 75%
      }

      .el-col-xs-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-xs-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-xs-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-xs-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-xs-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-xs-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-xs-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-xs-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-xs-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-xs-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-xs-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-xs-offset-21 {
        margin-left: 87.5%
      }

      .el-col-xs-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-xs-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-xs-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-xs-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-xs-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-xs-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-xs-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-xs-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-xs-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-xs-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-xs-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-xs-offset-24 {
        margin-left: 100%
      }

      .el-col-xs-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-xs-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:768px) {
      .el-col-sm-0 {
        display: none
      }

      .el-col-sm-0.is-guttered {
        display: none
      }

      .el-col-sm-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-sm-offset-0 {
        margin-left: 0
      }

      .el-col-sm-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-sm-push-0 {
        position: relative;
        left: 0
      }

      .el-col-sm-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-sm-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-sm-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-sm-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-sm-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-sm-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-sm-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-sm-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-sm-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-sm-offset-3 {
        margin-left: 12.5%
      }

      .el-col-sm-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-sm-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-sm-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-sm-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-sm-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-sm-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-sm-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-sm-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-sm-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-sm-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-sm-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-sm-offset-6 {
        margin-left: 25%
      }

      .el-col-sm-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-sm-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-sm-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-sm-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-sm-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-sm-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-sm-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-sm-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-sm-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-sm-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-sm-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-sm-offset-9 {
        margin-left: 37.5%
      }

      .el-col-sm-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-sm-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-sm-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-sm-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-sm-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-sm-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-sm-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-sm-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-sm-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-sm-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-sm-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-sm-offset-12 {
        margin-left: 50%
      }

      .el-col-sm-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-sm-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-sm-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-sm-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-sm-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-sm-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-sm-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-sm-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-sm-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-sm-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-sm-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-sm-offset-15 {
        margin-left: 62.5%
      }

      .el-col-sm-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-sm-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-sm-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-sm-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-sm-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-sm-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-sm-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-sm-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-sm-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-sm-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-sm-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-sm-offset-18 {
        margin-left: 75%
      }

      .el-col-sm-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-sm-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-sm-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-sm-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-sm-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-sm-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-sm-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-sm-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-sm-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-sm-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-sm-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-sm-offset-21 {
        margin-left: 87.5%
      }

      .el-col-sm-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-sm-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-sm-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-sm-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-sm-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-sm-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-sm-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-sm-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-sm-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-sm-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-sm-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-sm-offset-24 {
        margin-left: 100%
      }

      .el-col-sm-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-sm-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:992px) {
      .el-col-md-0 {
        display: none
      }

      .el-col-md-0.is-guttered {
        display: none
      }

      .el-col-md-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-md-offset-0 {
        margin-left: 0
      }

      .el-col-md-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-md-push-0 {
        position: relative;
        left: 0
      }

      .el-col-md-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-md-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-md-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-md-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-md-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-md-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-md-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-md-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-md-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-md-offset-3 {
        margin-left: 12.5%
      }

      .el-col-md-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-md-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-md-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-md-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-md-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-md-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-md-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-md-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-md-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-md-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-md-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-md-offset-6 {
        margin-left: 25%
      }

      .el-col-md-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-md-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-md-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-md-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-md-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-md-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-md-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-md-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-md-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-md-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-md-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-md-offset-9 {
        margin-left: 37.5%
      }

      .el-col-md-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-md-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-md-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-md-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-md-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-md-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-md-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-md-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-md-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-md-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-md-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-md-offset-12 {
        margin-left: 50%
      }

      .el-col-md-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-md-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-md-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-md-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-md-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-md-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-md-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-md-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-md-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-md-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-md-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-md-offset-15 {
        margin-left: 62.5%
      }

      .el-col-md-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-md-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-md-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-md-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-md-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-md-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-md-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-md-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-md-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-md-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-md-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-md-offset-18 {
        margin-left: 75%
      }

      .el-col-md-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-md-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-md-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-md-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-md-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-md-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-md-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-md-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-md-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-md-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-md-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-md-offset-21 {
        margin-left: 87.5%
      }

      .el-col-md-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-md-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-md-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-md-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-md-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-md-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-md-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-md-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-md-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-md-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-md-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-md-offset-24 {
        margin-left: 100%
      }

      .el-col-md-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-md-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:1200px) {
      .el-col-lg-0 {
        display: none
      }

      .el-col-lg-0.is-guttered {
        display: none
      }

      .el-col-lg-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-lg-offset-0 {
        margin-left: 0
      }

      .el-col-lg-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-lg-push-0 {
        position: relative;
        left: 0
      }

      .el-col-lg-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-lg-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-lg-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-lg-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-lg-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-lg-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-lg-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-lg-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-lg-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-lg-offset-3 {
        margin-left: 12.5%
      }

      .el-col-lg-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-lg-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-lg-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-lg-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-lg-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-lg-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-lg-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-lg-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-lg-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-lg-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-lg-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-lg-offset-6 {
        margin-left: 25%
      }

      .el-col-lg-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-lg-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-lg-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-lg-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-lg-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-lg-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-lg-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-lg-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-lg-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-lg-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-lg-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-lg-offset-9 {
        margin-left: 37.5%
      }

      .el-col-lg-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-lg-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-lg-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-lg-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-lg-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-lg-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-lg-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-lg-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-lg-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-lg-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-lg-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-lg-offset-12 {
        margin-left: 50%
      }

      .el-col-lg-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-lg-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-lg-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-lg-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-lg-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-lg-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-lg-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-lg-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-lg-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-lg-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-lg-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-lg-offset-15 {
        margin-left: 62.5%
      }

      .el-col-lg-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-lg-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-lg-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-lg-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-lg-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-lg-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-lg-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-lg-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-lg-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-lg-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-lg-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-lg-offset-18 {
        margin-left: 75%
      }

      .el-col-lg-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-lg-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-lg-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-lg-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-lg-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-lg-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-lg-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-lg-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-lg-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-lg-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-lg-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-lg-offset-21 {
        margin-left: 87.5%
      }

      .el-col-lg-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-lg-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-lg-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-lg-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-lg-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-lg-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-lg-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-lg-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-lg-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-lg-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-lg-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-lg-offset-24 {
        margin-left: 100%
      }

      .el-col-lg-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-lg-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:1920px) {
      .el-col-xl-0 {
        display: none
      }

      .el-col-xl-0.is-guttered {
        display: none
      }

      .el-col-xl-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-xl-offset-0 {
        margin-left: 0
      }

      .el-col-xl-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-xl-push-0 {
        position: relative;
        left: 0
      }

      .el-col-xl-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-xl-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-xl-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-xl-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-xl-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-xl-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-xl-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-xl-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-xl-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-xl-offset-3 {
        margin-left: 12.5%
      }

      .el-col-xl-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-xl-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-xl-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-xl-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-xl-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-xl-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-xl-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-xl-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-xl-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-xl-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-xl-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-xl-offset-6 {
        margin-left: 25%
      }

      .el-col-xl-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-xl-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-xl-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-xl-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-xl-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-xl-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-xl-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-xl-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-xl-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-xl-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-xl-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-xl-offset-9 {
        margin-left: 37.5%
      }

      .el-col-xl-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-xl-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-xl-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-xl-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-xl-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-xl-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-xl-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-xl-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-xl-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-xl-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-xl-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-xl-offset-12 {
        margin-left: 50%
      }

      .el-col-xl-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-xl-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-xl-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-xl-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-xl-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-xl-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-xl-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-xl-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-xl-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-xl-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-xl-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-xl-offset-15 {
        margin-left: 62.5%
      }

      .el-col-xl-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-xl-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-xl-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-xl-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-xl-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-xl-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-xl-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-xl-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-xl-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-xl-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-xl-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-xl-offset-18 {
        margin-left: 75%
      }

      .el-col-xl-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-xl-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-xl-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-xl-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-xl-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-xl-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-xl-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-xl-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-xl-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-xl-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-xl-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-xl-offset-21 {
        margin-left: 87.5%
      }

      .el-col-xl-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-xl-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-xl-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-xl-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-xl-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-xl-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-xl-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-xl-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-xl-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-xl-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-xl-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-xl-offset-24 {
        margin-left: 100%
      }

      .el-col-xl-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-xl-push-24 {
        position: relative;
        left: 100%
      }
    }

    .el-collapse {
      --el-collapse-border-color: var(--el-border-color-lighter);
      --el-collapse-header-height: 48px;
      --el-collapse-header-bg-color: var(--el-fill-color-blank);
      --el-collapse-header-text-color: var(--el-text-color-primary);
      --el-collapse-header-font-size: 13px;
      --el-collapse-content-bg-color: var(--el-fill-color-blank);
      --el-collapse-content-font-size: 13px;
      --el-collapse-content-text-color: var(--el-text-color-primary);
      border-top: 1px solid var(--el-collapse-border-color);
      border-bottom: 1px solid var(--el-collapse-border-color)
    }

    .el-collapse-item.is-disabled .el-collapse-item__header {
      color: var(--el-text-color-disabled);
      cursor: not-allowed
    }

    .el-collapse-item__header {
      width: 100%;
      padding: 0;
      border: none;
      display: flex;
      align-items: center;
      height: var(--el-collapse-header-height);
      line-height: var(--el-collapse-header-height);
      background-color: var(--el-collapse-header-bg-color);
      color: var(--el-collapse-header-text-color);
      cursor: pointer;
      border-bottom: 1px solid var(--el-collapse-border-color);
      font-size: var(--el-collapse-header-font-size);
      font-weight: 500;
      transition: border-bottom-color var(--el-transition-duration);
      outline: 0
    }

    .el-collapse-item__arrow {
      margin: 0 8px 0 auto;
      transition: transform var(--el-transition-duration);
      font-weight: 300
    }

    .el-collapse-item__arrow.is-active {
      transform: rotate(90deg)
    }

    .el-collapse-item__header.focusing:focus:not(:hover) {
      color: var(--el-color-primary)
    }

    .el-collapse-item__header.is-active {
      border-bottom-color: transparent
    }

    .el-collapse-item__wrap {
      will-change: height;
      background-color: var(--el-collapse-content-bg-color);
      overflow: hidden;
      box-sizing: border-box;
      border-bottom: 1px solid var(--el-collapse-border-color)
    }

    .el-collapse-item__content {
      padding-bottom: 25px;
      font-size: var(--el-collapse-content-font-size);
      color: var(--el-collapse-content-text-color);
      line-height: 1.7692307692
    }

    .el-collapse-item:last-child {
      margin-bottom: -1px
    }

    .el-color-predefine {
      display: flex;
      font-size: 12px;
      margin-top: 8px;
      width: 280px
    }

    .el-color-predefine__colors {
      display: flex;
      flex: 1;
      flex-wrap: wrap
    }

    .el-color-predefine__color-selector {
      margin: 0 0 8px 8px;
      width: 20px;
      height: 20px;
      border-radius: 4px;
      cursor: pointer
    }

    .el-color-predefine__color-selector:nth-child(10n+1) {
      margin-left: 0
    }

    .el-color-predefine__color-selector.selected {
      box-shadow: 0 0 3px 2px var(--el-color-primary)
    }

    .el-color-predefine__color-selector>div {
      display: flex;
      height: 100%;
      border-radius: 3px
    }

    .el-color-predefine__color-selector.is-alpha {
      background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAwAAAAMCAIAAADZF8uwAAAAGUlEQVQYV2M4gwH+YwCGIasIUwhT25BVBADtzYNYrHvv4gAAAABJRU5ErkJggg==)
    }

    .el-color-hue-slider {
      position: relative;
      box-sizing: border-box;
      width: 280px;
      height: 12px;
      background-color: red;
      padding: 0 2px;
      float: right
    }

    .el-color-hue-slider__bar {
      position: relative;
      background: linear-gradient(to right, red 0, #ff0 17%, #0f0 33%, #0ff 50%, #00f 67%, #f0f 83%, red 100%);
      height: 100%
    }

    .el-color-hue-slider__thumb {
      position: absolute;
      cursor: pointer;
      box-sizing: border-box;
      left: 0;
      top: 0;
      width: 4px;
      height: 100%;
      border-radius: 1px;
      background: #fff;
      border: 1px solid var(--el-border-color-lighter);
      box-shadow: 0 0 2px rgba(0, 0, 0, .6);
      z-index: 1
    }

    .el-color-hue-slider.is-vertical {
      width: 12px;
      height: 180px;
      padding: 2px 0
    }

    .el-color-hue-slider.is-vertical .el-color-hue-slider__bar {
      background: linear-gradient(to bottom, red 0, #ff0 17%, #0f0 33%, #0ff 50%, #00f 67%, #f0f 83%, red 100%)
    }

    .el-color-hue-slider.is-vertical .el-color-hue-slider__thumb {
      left: 0;
      top: 0;
      width: 100%;
      height: 4px
    }

    .el-color-svpanel {
      position: relative;
      width: 280px;
      height: 180px
    }

    .el-color-svpanel__black,
    .el-color-svpanel__white {
      position: absolute;
      top: 0;
      left: 0;
      right: 0;
      bottom: 0
    }

    .el-color-svpanel__white {
      background: linear-gradient(to right, #fff, rgba(255, 255, 255, 0))
    }

    .el-color-svpanel__black {
      background: linear-gradient(to top, #000, rgba(0, 0, 0, 0))
    }

    .el-color-svpanel__cursor {
      position: absolute
    }

    .el-color-svpanel__cursor>div {
      cursor: head;
      width: 4px;
      height: 4px;
      box-shadow: 0 0 0 1.5px #fff, inset 0 0 1px 1px rgba(0, 0, 0, .3), 0 0 1px 2px rgba(0, 0, 0, .4);
      border-radius: 50%;
      transform: translate(-2px, -2px)
    }

    .el-color-alpha-slider {
      position: relative;
      box-sizing: border-box;
      width: 280px;
      height: 12px;
      background-image: linear-gradient(45deg, var(--el-color-picker-alpha-bg-a) 25%, var(--el-color-picker-alpha-bg-b) 25%), linear-gradient(135deg, var(--el-color-picker-alpha-bg-a) 25%, var(--el-color-picker-alpha-bg-b) 25%), linear-gradient(45deg, var(--el-color-picker-alpha-bg-b) 75%, var(--el-color-picker-alpha-bg-a) 75%), linear-gradient(135deg, var(--el-color-picker-alpha-bg-b) 75%, var(--el-color-picker-alpha-bg-a) 75%);
      background-size: 12px 12px;
      background-position: 0 0, 6px 0, 6px -6px, 0 6px
    }

    .el-color-alpha-slider__bar {
      position: relative;
      background: linear-gradient(to right, rgba(255, 255, 255, 0) 0, var(--el-bg-color) 100%);
      height: 100%
    }

    .el-color-alpha-slider__thumb {
      position: absolute;
      cursor: pointer;
      box-sizing: border-box;
      left: 0;
      top: 0;
      width: 4px;
      height: 100%;
      border-radius: 1px;
      background: #fff;
      border: 1px solid var(--el-border-color-lighter);
      box-shadow: 0 0 2px rgba(0, 0, 0, .6);
      z-index: 1
    }

    .el-color-alpha-slider.is-vertical {
      width: 20px;
      height: 180px
    }

    .el-color-alpha-slider.is-vertical .el-color-alpha-slider__bar {
      background: linear-gradient(to bottom, rgba(255, 255, 255, 0) 0, #fff 100%)
    }

    .el-color-alpha-slider.is-vertical .el-color-alpha-slider__thumb {
      left: 0;
      top: 0;
      width: 100%;
      height: 4px
    }

    .el-color-dropdown {
      width: 300px
    }

    .el-color-dropdown__main-wrapper {
      margin-bottom: 6px
    }

    .el-color-dropdown__main-wrapper::after {
      content: """";
      display: table;
      clear: both
    }

    .el-color-dropdown__btns {
      margin-top: 12px;
      text-align: right
    }

    .el-color-dropdown__value {
      float: left;
      line-height: 26px;
      font-size: 12px;
      color: #000;
      width: 160px
    }

    .el-color-picker {
      display: inline-block;
      position: relative;
      line-height: normal;
      outline: 0
    }

    .el-color-picker:hover:not(.is-disabled, .is-focused) .el-color-picker__trigger {
      border-color: var(--el-border-color-hover)
    }

    .el-color-picker:focus-visible:not(.is-disabled) .el-color-picker__trigger {
      outline: 2px solid var(--el-color-primary);
      outline-offset: 1px
    }

    .el-color-picker.is-focused .el-color-picker__trigger {
      border-color: var(--el-color-primary)
    }

    .el-color-picker.is-disabled .el-color-picker__trigger {
      cursor: not-allowed
    }

    .el-color-picker--large {
      height: 40px
    }

    .el-color-picker--large .el-color-picker__trigger {
      height: 40px;
      width: 40px
    }

    .el-color-picker--large .el-color-picker__mask {
      height: 38px;
      width: 38px
    }

    .el-color-picker--small {
      height: 24px
    }

    .el-color-picker--small .el-color-picker__trigger {
      height: 24px;
      width: 24px
    }

    .el-color-picker--small .el-color-picker__mask {
      height: 22px;
      width: 22px
    }

    .el-color-picker--small .el-color-picker__empty,
    .el-color-picker--small .el-color-picker__icon {
      transform: scale(.8)
    }

    .el-color-picker__mask {
      height: 30px;
      width: 30px;
      border-radius: 4px;
      position: absolute;
      top: 1px;
      left: 1px;
      z-index: 1;
      cursor: not-allowed;
      background-color: rgba(255, 255, 255, .7)
    }

    .el-color-picker__trigger {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      box-sizing: border-box;
      height: 32px;
      width: 32px;
      padding: 4px;
      border: 1px solid var(--el-border-color);
      border-radius: 4px;
      font-size: 0;
      position: relative;
      cursor: pointer
    }

    .el-color-picker__color {
      position: relative;
      display: block;
      box-sizing: border-box;
      border: 1px solid var(--el-text-color-secondary);
      border-radius: var(--el-border-radius-small);
      width: 100%;
      height: 100%;
      text-align: center
    }

    .el-color-picker__color.is-alpha {
      background-image: linear-gradient(45deg, var(--el-color-picker-alpha-bg-a) 25%, var(--el-color-picker-alpha-bg-b) 25%), linear-gradient(135deg, var(--el-color-picker-alpha-bg-a) 25%, var(--el-color-picker-alpha-bg-b) 25%), linear-gradient(45deg, var(--el-color-picker-alpha-bg-b) 75%, var(--el-color-picker-alpha-bg-a) 75%), linear-gradient(135deg, var(--el-color-picker-alpha-bg-b) 75%, var(--el-color-picker-alpha-bg-a) 75%);
      background-size: 12px 12px;
      background-position: 0 0, 6px 0, 6px -6px, 0 6px
    }

    .el-color-picker__color-inner {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      width: 100%;
      height: 100%
    }

    .el-color-picker .el-color-picker__empty {
      font-size: 12px;
      color: var(--el-text-color-secondary)
    }

    .el-color-picker .el-color-picker__icon {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      color: #fff;
      font-size: 12px
    }

    .el-color-picker__panel {
      position: absolute;
      z-index: 10;
      padding: 6px;
      box-sizing: content-box;
      background-color: #fff;
      border-radius: var(--el-border-radius-base);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-color-picker__panel.el-popper {
      border: 1px solid var(--el-border-color-lighter)
    }

    .el-color-picker,
    .el-color-picker__panel {
      --el-color-picker-alpha-bg-a: #ccc;
      --el-color-picker-alpha-bg-b: transparent
    }

    .dark .el-color-picker,
    .dark .el-color-picker__panel {
      --el-color-picker-alpha-bg-a: #333333
    }

    .el-container {
      display: flex;
      flex-direction: row;
      flex: 1;
      flex-basis: auto;
      box-sizing: border-box;
      min-width: 0
    }

    .el-container.is-vertical {
      flex-direction: column
    }

    .el-date-table {
      font-size: 12px;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-date-table.is-week-mode .el-date-table__row:hover .el-date-table-cell {
      background-color: var(--el-datepicker-inrange-bg-color)
    }

    .el-date-table.is-week-mode .el-date-table__row:hover td.available:hover {
      color: var(--el-datepicker-text-color)
    }

    .el-date-table.is-week-mode .el-date-table__row:hover td:first-child .el-date-table-cell {
      margin-left: 5px;
      border-top-left-radius: 15px;
      border-bottom-left-radius: 15px
    }

    .el-date-table.is-week-mode .el-date-table__row:hover td:last-child .el-date-table-cell {
      margin-right: 5px;
      border-top-right-radius: 15px;
      border-bottom-right-radius: 15px
    }

    .el-date-table.is-week-mode .el-date-table__row.current .el-date-table-cell {
      background-color: var(--el-datepicker-inrange-bg-color)
    }

    .el-date-table td {
      width: 32px;
      height: 30px;
      padding: 4px 0;
      box-sizing: border-box;
      text-align: center;
      cursor: pointer;
      position: relative
    }

    .el-date-table td .el-date-table-cell {
      height: 30px;
      padding: 3px 0;
      box-sizing: border-box
    }

    .el-date-table td .el-date-table-cell .el-date-table-cell__text {
      width: 24px;
      height: 24px;
      display: block;
      margin: 0 auto;
      line-height: 24px;
      position: absolute;
      left: 50%;
      transform: translateX(-50%);
      border-radius: 50%
    }

    .el-date-table td.next-month,
    .el-date-table td.prev-month {
      color: var(--el-datepicker-off-text-color)
    }

    .el-date-table td.today {
      position: relative
    }

    .el-date-table td.today .el-date-table-cell__text {
      color: var(--el-color-primary);
      font-weight: 700
    }

    .el-date-table td.today.end-date .el-date-table-cell__text,
    .el-date-table td.today.start-date .el-date-table-cell__text {
      color: #fff
    }

    .el-date-table td.available:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-date-table td.in-range .el-date-table-cell {
      background-color: var(--el-datepicker-inrange-bg-color)
    }

    .el-date-table td.in-range .el-date-table-cell:hover {
      background-color: var(--el-datepicker-inrange-hover-bg-color)
    }

    .el-date-table td.current:not(.disabled) .el-date-table-cell__text {
      color: #fff;
      background-color: var(--el-datepicker-active-color)
    }

    .el-date-table td.current:not(.disabled):focus-visible .el-date-table-cell__text {
      outline: 2px solid var(--el-datepicker-active-color);
      outline-offset: 1px
    }

    .el-date-table td.end-date .el-date-table-cell,
    .el-date-table td.start-date .el-date-table-cell {
      color: #fff
    }

    .el-date-table td.end-date .el-date-table-cell__text,
    .el-date-table td.start-date .el-date-table-cell__text {
      background-color: var(--el-datepicker-active-color)
    }

    .el-date-table td.start-date .el-date-table-cell {
      margin-left: 5px;
      border-top-left-radius: 15px;
      border-bottom-left-radius: 15px
    }

    .el-date-table td.end-date .el-date-table-cell {
      margin-right: 5px;
      border-top-right-radius: 15px;
      border-bottom-right-radius: 15px
    }

    .el-date-table td.disabled .el-date-table-cell {
      background-color: var(--el-fill-color-light);
      opacity: 1;
      cursor: not-allowed;
      color: var(--el-text-color-placeholder)
    }

    .el-date-table td.selected .el-date-table-cell {
      margin-left: 5px;
      margin-right: 5px;
      background-color: var(--el-datepicker-inrange-bg-color);
      border-radius: 15px
    }

    .el-date-table td.selected .el-date-table-cell:hover {
      background-color: var(--el-datepicker-inrange-hover-bg-color)
    }

    .el-date-table td.selected .el-date-table-cell__text {
      background-color: var(--el-datepicker-active-color);
      color: #fff;
      border-radius: 15px
    }

    .el-date-table td.week {
      font-size: 80%;
      color: var(--el-datepicker-header-text-color)
    }

    .el-date-table td:focus {
      outline: 0
    }

    .el-date-table th {
      padding: 5px;
      color: var(--el-datepicker-header-text-color);
      font-weight: 400;
      border-bottom: solid 1px var(--el-border-color-lighter)
    }

    .el-month-table {
      font-size: 12px;
      margin: -1px;
      border-collapse: collapse
    }

    .el-month-table td {
      text-align: center;
      padding: 8px 0;
      cursor: pointer
    }

    .el-month-table td div {
      height: 48px;
      padding: 6px 0;
      box-sizing: border-box
    }

    .el-month-table td.today .cell {
      color: var(--el-color-primary);
      font-weight: 700
    }

    .el-month-table td.today.end-date .cell,
    .el-month-table td.today.start-date .cell {
      color: #fff
    }

    .el-month-table td.disabled .cell {
      background-color: var(--el-fill-color-light);
      cursor: not-allowed;
      color: var(--el-text-color-placeholder)
    }

    .el-month-table td.disabled .cell:hover {
      color: var(--el-text-color-placeholder)
    }

    .el-month-table td .cell {
      width: 60px;
      height: 36px;
      display: block;
      line-height: 36px;
      color: var(--el-datepicker-text-color);
      margin: 0 auto;
      border-radius: 18px
    }

    .el-month-table td .cell:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-month-table td.in-range div {
      background-color: var(--el-datepicker-inrange-bg-color)
    }

    .el-month-table td.in-range div:hover {
      background-color: var(--el-datepicker-inrange-hover-bg-color)
    }

    .el-month-table td.end-date div,
    .el-month-table td.start-date div {
      color: #fff
    }

    .el-month-table td.end-date .cell,
    .el-month-table td.start-date .cell {
      color: #fff;
      background-color: var(--el-datepicker-active-color)
    }

    .el-month-table td.start-date div {
      border-top-left-radius: 24px;
      border-bottom-left-radius: 24px
    }

    .el-month-table td.end-date div {
      border-top-right-radius: 24px;
      border-bottom-right-radius: 24px
    }

    .el-month-table td.current:not(.disabled) .cell {
      color: var(--el-datepicker-active-color)
    }

    .el-month-table td:focus-visible {
      outline: 0
    }

    .el-month-table td:focus-visible .cell {
      outline: 2px solid var(--el-datepicker-active-color)
    }

    .el-year-table {
      font-size: 12px;
      margin: -1px;
      border-collapse: collapse
    }

    .el-year-table .el-icon {
      color: var(--el-datepicker-icon-color)
    }

    .el-year-table td {
      text-align: center;
      padding: 20px 3px;
      cursor: pointer
    }

    .el-year-table td.today .cell {
      color: var(--el-color-primary);
      font-weight: 700
    }

    .el-year-table td.disabled .cell {
      background-color: var(--el-fill-color-light);
      cursor: not-allowed;
      color: var(--el-text-color-placeholder)
    }

    .el-year-table td.disabled .cell:hover {
      color: var(--el-text-color-placeholder)
    }

    .el-year-table td .cell {
      width: 48px;
      height: 36px;
      display: block;
      line-height: 36px;
      color: var(--el-datepicker-text-color);
      border-radius: 18px;
      margin: 0 auto
    }

    .el-year-table td .cell:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-year-table td.current:not(.disabled) .cell {
      color: var(--el-datepicker-active-color)
    }

    .el-year-table td:focus-visible {
      outline: 0
    }

    .el-year-table td:focus-visible .cell {
      outline: 2px solid var(--el-datepicker-active-color)
    }

    .el-time-spinner.has-seconds .el-time-spinner__wrapper {
      width: 33.3%
    }

    .el-time-spinner__wrapper {
      max-height: 192px;
      overflow: auto;
      display: inline-block;
      width: 50%;
      vertical-align: top;
      position: relative
    }

    .el-time-spinner__wrapper.el-scrollbar__wrap:not(.el-scrollbar__wrap--hidden-default) {
      padding-bottom: 15px
    }

    .el-time-spinner__wrapper.is-arrow {
      box-sizing: border-box;
      text-align: center;
      overflow: hidden
    }

    .el-time-spinner__wrapper.is-arrow .el-time-spinner__list {
      transform: translateY(-32px)
    }

    .el-time-spinner__wrapper.is-arrow .el-time-spinner__item:hover:not(.is-disabled):not(.is-active) {
      background: var(--el-fill-color-light);
      cursor: default
    }

    .el-time-spinner__arrow {
      font-size: 12px;
      color: var(--el-text-color-secondary);
      position: absolute;
      left: 0;
      width: 100%;
      z-index: var(--el-index-normal);
      text-align: center;
      height: 30px;
      line-height: 30px;
      cursor: pointer
    }

    .el-time-spinner__arrow:hover {
      color: var(--el-color-primary)
    }

    .el-time-spinner__arrow.arrow-up {
      top: 10px
    }

    .el-time-spinner__arrow.arrow-down {
      bottom: 10px
    }

    .el-time-spinner__input.el-input {
      width: 70%
    }

    .el-time-spinner__input.el-input .el-input__inner {
      padding: 0;
      text-align: center
    }

    .el-time-spinner__list {
      padding: 0;
      margin: 0;
      list-style: none;
      text-align: center
    }

    .el-time-spinner__list::after,
    .el-time-spinner__list::before {
      content: """";
      display: block;
      width: 100%;
      height: 80px
    }

    .el-time-spinner__item {
      height: 32px;
      line-height: 32px;
      font-size: 12px;
      color: var(--el-text-color-regular)
    }

    .el-time-spinner__item:hover:not(.is-disabled):not(.is-active) {
      background: var(--el-fill-color-light);
      cursor: pointer
    }

    .el-time-spinner__item.is-active:not(.is-disabled) {
      color: var(--el-text-color-primary);
      font-weight: 700
    }

    .el-time-spinner__item.is-disabled {
      color: var(--el-text-color-placeholder);
      cursor: not-allowed
    }

    .el-picker__popper {
      --el-datepicker-border-color: var(--el-disabled-border-color)
    }

    .el-picker__popper.el-popper {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-datepicker-border-color);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-picker__popper.el-popper .el-popper__arrow::before {
      border: 1px solid var(--el-datepicker-border-color)
    }

    .el-picker__popper.el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-picker__popper.el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-picker__popper.el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-picker__popper.el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-date-editor {
      --el-date-editor-width: 220px;
      --el-date-editor-monthrange-width: 300px;
      --el-date-editor-daterange-width: 350px;
      --el-date-editor-datetimerange-width: 400px;
      --el-input-text-color: var(--el-text-color-regular);
      --el-input-border: var(--el-border);
      --el-input-hover-border: var(--el-border-color-hover);
      --el-input-focus-border: var(--el-color-primary);
      --el-input-transparent-border: 0 0 0 1px transparent inset;
      --el-input-border-color: var(--el-border-color);
      --el-input-border-radius: var(--el-border-radius-base);
      --el-input-bg-color: var(--el-fill-color-blank);
      --el-input-icon-color: var(--el-text-color-placeholder);
      --el-input-placeholder-color: var(--el-text-color-placeholder);
      --el-input-hover-border-color: var(--el-border-color-hover);
      --el-input-clear-hover-color: var(--el-text-color-secondary);
      --el-input-focus-border-color: var(--el-color-primary);
      --el-input-width: 100%;
      position: relative;
      text-align: left;
      vertical-align: middle
    }

    .el-date-editor.el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-input-border-color, var(--el-border-color)) inset
    }

    .el-date-editor.el-input__wrapper:hover {
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-date-editor.el-input,
    .el-date-editor.el-input__wrapper {
      width: var(--el-date-editor-width);
      height: var(--el-input-height, var(--el-component-size))
    }

    .el-date-editor--monthrange {
      --el-date-editor-width: var(--el-date-editor-monthrange-width)
    }

    .el-date-editor--daterange,
    .el-date-editor--timerange {
      --el-date-editor-width: var(--el-date-editor-daterange-width)
    }

    .el-date-editor--datetimerange {
      --el-date-editor-width: var(--el-date-editor-datetimerange-width)
    }

    .el-date-editor--dates .el-input__wrapper {
      text-overflow: ellipsis;
      white-space: nowrap
    }

    .el-date-editor .close-icon {
      cursor: pointer
    }

    .el-date-editor .clear-icon {
      cursor: pointer
    }

    .el-date-editor .clear-icon:hover {
      color: var(--el-text-color-secondary)
    }

    .el-date-editor .el-range__icon {
      height: inherit;
      font-size: 14px;
      color: var(--el-text-color-placeholder);
      float: left
    }

    .el-date-editor .el-range__icon svg {
      vertical-align: middle
    }

    .el-date-editor .el-range-input {
      -webkit-appearance: none;
      -moz-appearance: none;
      appearance: none;
      border: none;
      outline: 0;
      display: inline-block;
      height: 30px;
      line-height: 30px;
      margin: 0;
      padding: 0;
      width: 39%;
      text-align: center;
      font-size: var(--el-font-size-base);
      color: var(--el-text-color-regular);
      background-color: transparent
    }

    .el-date-editor .el-range-input::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-date-editor .el-range-input:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-date-editor .el-range-input::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-date-editor .el-range-separator {
      flex: 1;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      height: 100%;
      padding: 0 5px;
      margin: 0;
      font-size: 14px;
      overflow-wrap: break-word;
      color: var(--el-text-color-primary)
    }

    .el-date-editor .el-range__close-icon {
      font-size: 14px;
      color: var(--el-text-color-placeholder);
      height: inherit;
      width: unset;
      cursor: pointer
    }

    .el-date-editor .el-range__close-icon:hover {
      color: var(--el-text-color-secondary)
    }

    .el-date-editor .el-range__close-icon svg {
      vertical-align: middle
    }

    .el-date-editor .el-range__close-icon--hidden {
      opacity: 0;
      visibility: hidden
    }

    .el-range-editor.el-input__wrapper {
      display: inline-flex;
      align-items: center;
      padding: 0 10px
    }

    .el-range-editor.is-active {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-range-editor.is-active:hover {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-range-editor--large {
      line-height: var(--el-component-size-large)
    }

    .el-range-editor--large.el-input__wrapper {
      height: var(--el-component-size-large)
    }

    .el-range-editor--large .el-range-separator {
      line-height: 40px;
      font-size: 14px
    }

    .el-range-editor--large .el-range-input {
      height: 38px;
      line-height: 38px;
      font-size: 14px
    }

    .el-range-editor--small {
      line-height: var(--el-component-size-small)
    }

    .el-range-editor--small.el-input__wrapper {
      height: var(--el-component-size-small)
    }

    .el-range-editor--small .el-range-separator {
      line-height: 24px;
      font-size: 12px
    }

    .el-range-editor--small .el-range-input {
      height: 22px;
      line-height: 22px;
      font-size: 12px
    }

    .el-range-editor.is-disabled {
      background-color: var(--el-disabled-bg-color);
      border-color: var(--el-disabled-border-color);
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-range-editor.is-disabled:focus,
    .el-range-editor.is-disabled:hover {
      border-color: var(--el-disabled-border-color)
    }

    .el-range-editor.is-disabled input {
      background-color: var(--el-disabled-bg-color);
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-range-editor.is-disabled input::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-range-editor.is-disabled input:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-range-editor.is-disabled input::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-range-editor.is-disabled .el-range-separator {
      color: var(--el-disabled-text-color)
    }

    .el-picker-panel {
      color: var(--el-text-color-regular);
      background: var(--el-bg-color-overlay);
      border-radius: var(--el-border-radius-base);
      line-height: 30px
    }

    .el-picker-panel .el-time-panel {
      margin: 5px 0;
      border: solid 1px var(--el-datepicker-border-color);
      background-color: var(--el-bg-color-overlay);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-picker-panel__body-wrapper::after,
    .el-picker-panel__body::after {
      content: """";
      display: table;
      clear: both
    }

    .el-picker-panel__content {
      position: relative;
      margin: 15px
    }

    .el-picker-panel__footer {
      border-top: 1px solid var(--el-datepicker-inner-border-color);
      padding: 4px 12px;
      text-align: right;
      background-color: var(--el-bg-color-overlay);
      position: relative;
      font-size: 0
    }

    .el-picker-panel__shortcut {
      display: block;
      width: 100%;
      border: 0;
      background-color: transparent;
      line-height: 28px;
      font-size: 14px;
      color: var(--el-datepicker-text-color);
      padding-left: 12px;
      text-align: left;
      outline: 0;
      cursor: pointer
    }

    .el-picker-panel__shortcut:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-picker-panel__shortcut.active {
      background-color: #e6f1fe;
      color: var(--el-datepicker-active-color)
    }

    .el-picker-panel__btn {
      border: 1px solid var(--el-fill-color-darker);
      color: var(--el-text-color-primary);
      line-height: 24px;
      border-radius: 2px;
      padding: 0 20px;
      cursor: pointer;
      background-color: transparent;
      outline: 0;
      font-size: 12px
    }

    .el-picker-panel__btn[disabled] {
      color: var(--el-text-color-disabled);
      cursor: not-allowed
    }

    .el-picker-panel__icon-btn {
      font-size: 12px;
      color: var(--el-datepicker-icon-color);
      border: 0;
      background: 0 0;
      cursor: pointer;
      outline: 0;
      margin-top: 8px
    }

    .el-picker-panel__icon-btn:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-picker-panel__icon-btn:focus-visible {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-picker-panel__icon-btn.is-disabled {
      color: var(--el-text-color-disabled)
    }

    .el-picker-panel__icon-btn.is-disabled:hover {
      cursor: not-allowed
    }

    .el-picker-panel__icon-btn .el-icon {
      cursor: pointer;
      font-size: inherit
    }

    .el-picker-panel__link-btn {
      vertical-align: middle
    }

    .el-picker-panel [slot=sidebar],
    .el-picker-panel__sidebar {
      position: absolute;
      top: 0;
      bottom: 0;
      width: 110px;
      border-right: 1px solid var(--el-datepicker-inner-border-color);
      box-sizing: border-box;
      padding-top: 6px;
      background-color: var(--el-bg-color-overlay);
      overflow: auto
    }

    .el-picker-panel [slot=sidebar]+.el-picker-panel__body,
    .el-picker-panel__sidebar+.el-picker-panel__body {
      margin-left: 110px
    }

    .el-date-picker {
      --el-datepicker-text-color: var(--el-text-color-regular);
      --el-datepicker-off-text-color: var(--el-text-color-placeholder);
      --el-datepicker-header-text-color: var(--el-text-color-regular);
      --el-datepicker-icon-color: var(--el-text-color-primary);
      --el-datepicker-border-color: var(--el-disabled-border-color);
      --el-datepicker-inner-border-color: var(--el-border-color-light);
      --el-datepicker-inrange-bg-color: var(--el-border-color-extra-light);
      --el-datepicker-inrange-hover-bg-color: var(--el-border-color-extra-light);
      --el-datepicker-active-color: var(--el-color-primary);
      --el-datepicker-hover-text-color: var(--el-color-primary)
    }

    .el-date-picker {
      width: 322px
    }

    .el-date-picker.has-sidebar.has-time {
      width: 434px
    }

    .el-date-picker.has-sidebar {
      width: 438px
    }

    .el-date-picker.has-time .el-picker-panel__body-wrapper {
      position: relative
    }

    .el-date-picker .el-picker-panel__content {
      width: 292px
    }

    .el-date-picker table {
      table-layout: fixed;
      width: 100%
    }

    .el-date-picker__editor-wrap {
      position: relative;
      display: table-cell;
      padding: 0 5px
    }

    .el-date-picker__time-header {
      position: relative;
      border-bottom: 1px solid var(--el-datepicker-inner-border-color);
      font-size: 12px;
      padding: 8px 5px 5px;
      display: table;
      width: 100%;
      box-sizing: border-box
    }

    .el-date-picker__header {
      margin: 12px;
      text-align: center
    }

    .el-date-picker__header--bordered {
      margin-bottom: 0;
      padding-bottom: 12px;
      border-bottom: solid 1px var(--el-border-color-lighter)
    }

    .el-date-picker__header--bordered+.el-picker-panel__content {
      margin-top: 0
    }

    .el-date-picker__header-label {
      font-size: 16px;
      font-weight: 500;
      padding: 0 5px;
      line-height: 22px;
      text-align: center;
      cursor: pointer;
      color: var(--el-text-color-regular)
    }

    .el-date-picker__header-label:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-date-picker__header-label:focus-visible {
      outline: 0;
      color: var(--el-datepicker-hover-text-color)
    }

    .el-date-picker__header-label.active {
      color: var(--el-datepicker-active-color)
    }

    .el-date-picker__prev-btn {
      float: left
    }

    .el-date-picker__next-btn {
      float: right
    }

    .el-date-picker__time-wrap {
      padding: 10px;
      text-align: center
    }

    .el-date-picker__time-label {
      float: left;
      cursor: pointer;
      line-height: 30px;
      margin-left: 10px
    }

    .el-date-picker .el-time-panel {
      position: absolute
    }

    .el-date-range-picker {
      --el-datepicker-text-color: var(--el-text-color-regular);
      --el-datepicker-off-text-color: var(--el-text-color-placeholder);
      --el-datepicker-header-text-color: var(--el-text-color-regular);
      --el-datepicker-icon-color: var(--el-text-color-primary);
      --el-datepicker-border-color: var(--el-disabled-border-color);
      --el-datepicker-inner-border-color: var(--el-border-color-light);
      --el-datepicker-inrange-bg-color: var(--el-border-color-extra-light);
      --el-datepicker-inrange-hover-bg-color: var(--el-border-color-extra-light);
      --el-datepicker-active-color: var(--el-color-primary);
      --el-datepicker-hover-text-color: var(--el-color-primary)
    }

    .el-date-range-picker {
      width: 646px
    }

    .el-date-range-picker.has-sidebar {
      width: 756px
    }

    .el-date-range-picker.has-time .el-picker-panel__body-wrapper {
      position: relative
    }

    .el-date-range-picker table {
      table-layout: fixed;
      width: 100%
    }

    .el-date-range-picker .el-picker-panel__body {
      min-width: 513px
    }

    .el-date-range-picker .el-picker-panel__content {
      margin: 0
    }

    .el-date-range-picker__header {
      position: relative;
      text-align: center;
      height: 28px
    }

    .el-date-range-picker__header [class*=arrow-left] {
      float: left
    }

    .el-date-range-picker__header [class*=arrow-right] {
      float: right
    }

    .el-date-range-picker__header div {
      font-size: 16px;
      font-weight: 500;
      margin-right: 50px
    }

    .el-date-range-picker__content {
      float: left;
      width: 50%;
      box-sizing: border-box;
      margin: 0;
      padding: 16px
    }

    .el-date-range-picker__content.is-left {
      border-right: 1px solid var(--el-datepicker-inner-border-color)
    }

    .el-date-range-picker__content .el-date-range-picker__header div {
      margin-left: 50px;
      margin-right: 50px
    }

    .el-date-range-picker__editors-wrap {
      box-sizing: border-box;
      display: table-cell
    }

    .el-date-range-picker__editors-wrap.is-right {
      text-align: right
    }

    .el-date-range-picker__time-header {
      position: relative;
      border-bottom: 1px solid var(--el-datepicker-inner-border-color);
      font-size: 12px;
      padding: 8px 5px 5px 5px;
      display: table;
      width: 100%;
      box-sizing: border-box
    }

    .el-date-range-picker__time-header>.el-icon-arrow-right {
      font-size: 20px;
      vertical-align: middle;
      display: table-cell;
      color: var(--el-datepicker-icon-color)
    }

    .el-date-range-picker__time-picker-wrap {
      position: relative;
      display: table-cell;
      padding: 0 5px
    }

    .el-date-range-picker__time-picker-wrap .el-picker-panel {
      position: absolute;
      top: 13px;
      right: 0;
      z-index: 1;
      background: #fff
    }

    .el-date-range-picker__time-picker-wrap .el-time-panel {
      position: absolute
    }

    .el-time-range-picker {
      width: 354px;
      overflow: visible
    }

    .el-time-range-picker__content {
      position: relative;
      text-align: center;
      padding: 10px;
      z-index: 1
    }

    .el-time-range-picker__cell {
      box-sizing: border-box;
      margin: 0;
      padding: 4px 7px 7px;
      width: 50%;
      display: inline-block
    }

    .el-time-range-picker__header {
      margin-bottom: 5px;
      text-align: center;
      font-size: 14px
    }

    .el-time-range-picker__body {
      border-radius: 2px;
      border: 1px solid var(--el-datepicker-border-color)
    }

    .el-time-panel {
      border-radius: 2px;
      position: relative;
      width: 180px;
      left: 0;
      z-index: var(--el-index-top);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      box-sizing: content-box
    }

    .el-time-panel__content {
      font-size: 0;
      position: relative;
      overflow: hidden
    }

    .el-time-panel__content::after,
    .el-time-panel__content::before {
      content: """";
      top: 50%;
      position: absolute;
      margin-top: -16px;
      height: 32px;
      z-index: -1;
      left: 0;
      right: 0;
      box-sizing: border-box;
      padding-top: 6px;
      text-align: left
    }

    .el-time-panel__content::after {
      left: 50%;
      margin-left: 12%;
      margin-right: 12%
    }

    .el-time-panel__content::before {
      padding-left: 50%;
      margin-right: 12%;
      margin-left: 12%;
      border-top: 1px solid var(--el-border-color-light);
      border-bottom: 1px solid var(--el-border-color-light)
    }

    .el-time-panel__content.has-seconds::after {
      left: 66.6666666667%
    }

    .el-time-panel__content.has-seconds::before {
      padding-left: 33.3333333333%
    }

    .el-time-panel__footer {
      border-top: 1px solid var(--el-timepicker-inner-border-color, var(--el-border-color-light));
      padding: 4px;
      height: 36px;
      line-height: 25px;
      text-align: right;
      box-sizing: border-box
    }

    .el-time-panel__btn {
      border: none;
      line-height: 28px;
      padding: 0 5px;
      margin: 0 5px;
      cursor: pointer;
      background-color: transparent;
      outline: 0;
      font-size: 12px;
      color: var(--el-text-color-primary)
    }

    .el-time-panel__btn.confirm {
      font-weight: 800;
      color: var(--el-timepicker-active-color, var(--el-color-primary))
    }

    .el-descriptions {
      --el-descriptions-table-border: 1px solid var(--el-border-color-lighter);
      --el-descriptions-item-bordered-label-background: var(--el-fill-color-light);
      box-sizing: border-box;
      font-size: var(--el-font-size-base);
      color: var(--el-text-color-primary)
    }

    .el-descriptions__header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-bottom: 16px
    }

    .el-descriptions__title {
      color: var(--el-text-color-primary);
      font-size: 16px;
      font-weight: 700
    }

    .el-descriptions__body {
      background-color: var(--el-fill-color-blank)
    }

    .el-descriptions__body .el-descriptions__table {
      border-collapse: collapse;
      width: 100%
    }

    .el-descriptions__body .el-descriptions__table .el-descriptions__cell {
      box-sizing: border-box;
      text-align: left;
      font-weight: 400;
      line-height: 23px;
      font-size: 14px
    }

    .el-descriptions__body .el-descriptions__table .el-descriptions__cell.is-left {
      text-align: left
    }

    .el-descriptions__body .el-descriptions__table .el-descriptions__cell.is-center {
      text-align: center
    }

    .el-descriptions__body .el-descriptions__table .el-descriptions__cell.is-right {
      text-align: right
    }

    .el-descriptions__body .el-descriptions__table.is-bordered .el-descriptions__cell {
      border: var(--el-descriptions-table-border);
      padding: 8px 11px
    }

    .el-descriptions__body .el-descriptions__table:not(.is-bordered) .el-descriptions__cell {
      padding-bottom: 12px
    }

    .el-descriptions--large {
      font-size: 14px
    }

    .el-descriptions--large .el-descriptions__header {
      margin-bottom: 20px
    }

    .el-descriptions--large .el-descriptions__header .el-descriptions__title {
      font-size: 16px
    }

    .el-descriptions--large .el-descriptions__body .el-descriptions__table .el-descriptions__cell {
      font-size: 14px
    }

    .el-descriptions--large .el-descriptions__body .el-descriptions__table.is-bordered .el-descriptions__cell {
      padding: 12px 15px
    }

    .el-descriptions--large .el-descriptions__body .el-descriptions__table:not(.is-bordered) .el-descriptions__cell {
      padding-bottom: 16px
    }

    .el-descriptions--small {
      font-size: 12px
    }

    .el-descriptions--small .el-descriptions__header {
      margin-bottom: 12px
    }

    .el-descriptions--small .el-descriptions__header .el-descriptions__title {
      font-size: 14px
    }

    .el-descriptions--small .el-descriptions__body .el-descriptions__table .el-descriptions__cell {
      font-size: 12px
    }

    .el-descriptions--small .el-descriptions__body .el-descriptions__table.is-bordered .el-descriptions__cell {
      padding: 4px 7px
    }

    .el-descriptions--small .el-descriptions__body .el-descriptions__table:not(.is-bordered) .el-descriptions__cell {
      padding-bottom: 8px
    }

    .el-descriptions__label.el-descriptions__cell.is-bordered-label {
      font-weight: 700;
      color: var(--el-text-color-regular);
      background: var(--el-descriptions-item-bordered-label-background)
    }

    .el-descriptions__label:not(.is-bordered-label) {
      color: var(--el-text-color-primary);
      margin-right: 16px
    }

    .el-descriptions__label.el-descriptions__cell:not(.is-bordered-label).is-vertical-label {
      padding-bottom: 6px
    }

    .el-descriptions__content.el-descriptions__cell.is-bordered-content {
      color: var(--el-text-color-primary)
    }

    .el-descriptions__content:not(.is-bordered-label) {
      color: var(--el-text-color-regular)
    }

    .el-descriptions--large .el-descriptions__label:not(.is-bordered-label) {
      margin-right: 16px
    }

    .el-descriptions--large .el-descriptions__label.el-descriptions__cell:not(.is-bordered-label).is-vertical-label {
      padding-bottom: 8px
    }

    .el-descriptions--small .el-descriptions__label:not(.is-bordered-label) {
      margin-right: 12px
    }

    .el-descriptions--small .el-descriptions__label.el-descriptions__cell:not(.is-bordered-label).is-vertical-label {
      padding-bottom: 4px
    }

    :root {
      --el-popup-modal-bg-color: var(--el-color-black);
      --el-popup-modal-opacity: 0.5
    }

    .v-modal-enter {
      -webkit-animation: v-modal-in var(--el-transition-duration-fast) ease;
      animation: v-modal-in var(--el-transition-duration-fast) ease
    }

    .v-modal-leave {
      -webkit-animation: v-modal-out var(--el-transition-duration-fast) ease forwards;
      animation: v-modal-out var(--el-transition-duration-fast) ease forwards
    }

    @-webkit-keyframes v-modal-in {
      0% {
        opacity: 0
      }
    }

    @keyframes v-modal-in {
      0% {
        opacity: 0
      }
    }

    @-webkit-keyframes v-modal-out {
      100% {
        opacity: 0
      }
    }

    @keyframes v-modal-out {
      100% {
        opacity: 0
      }
    }

    .v-modal {
      position: fixed;
      left: 0;
      top: 0;
      width: 100%;
      height: 100%;
      opacity: var(--el-popup-modal-opacity);
      background: var(--el-popup-modal-bg-color)
    }

    .el-popup-parent--hidden {
      overflow: hidden
    }

    .el-dialog {
      --el-dialog-width: 50%;
      --el-dialog-margin-top: 15vh;
      --el-dialog-bg-color: var(--el-bg-color);
      --el-dialog-box-shadow: var(--el-box-shadow);
      --el-dialog-title-font-size: var(--el-font-size-large);
      --el-dialog-content-font-size: 14px;
      --el-dialog-font-line-height: var(--el-font-line-height-primary);
      --el-dialog-padding-primary: 16px;
      --el-dialog-border-radius: var(--el-border-radius-small);
      position: relative;
      margin: var(--el-dialog-margin-top, 15vh) auto 50px;
      background: var(--el-dialog-bg-color);
      border-radius: var(--el-dialog-border-radius);
      box-shadow: var(--el-dialog-box-shadow);
      box-sizing: border-box;
      padding: var(--el-dialog-padding-primary);
      width: var(--el-dialog-width, 50%);
      overflow-wrap: break-word
    }

    .el-dialog:focus {
      outline: 0 !important
    }

    .el-dialog.is-align-center {
      margin: auto
    }

    .el-dialog.is-fullscreen {
      --el-dialog-width: 100%;
      --el-dialog-margin-top: 0;
      margin-bottom: 0;
      height: 100%;
      overflow: auto
    }

    .el-dialog__wrapper {
      position: fixed;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      overflow: auto;
      margin: 0
    }

    .el-dialog.is-draggable .el-dialog__header {
      cursor: move;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-dialog__header {
      padding-bottom: var(--el-dialog-padding-primary)
    }

    .el-dialog__header.show-close {
      padding-right: calc(var(--el-dialog-padding-primary) + var(--el-message-close-size, 16px))
    }

    .el-dialog__headerbtn {
      position: absolute;
      top: 0;
      right: 0;
      padding: 0;
      width: 48px;
      height: 48px;
      background: 0 0;
      border: none;
      outline: 0;
      cursor: pointer;
      font-size: var(--el-message-close-size, 16px)
    }

    .el-dialog__headerbtn .el-dialog__close {
      color: var(--el-color-info);
      font-size: inherit
    }

    .el-dialog__headerbtn:focus .el-dialog__close,
    .el-dialog__headerbtn:hover .el-dialog__close {
      color: var(--el-color-primary)
    }

    .el-dialog__title {
      line-height: var(--el-dialog-font-line-height);
      font-size: var(--el-dialog-title-font-size);
      color: var(--el-text-color-primary)
    }

    .el-dialog__body {
      color: var(--el-text-color-regular);
      font-size: var(--el-dialog-content-font-size)
    }

    .el-dialog__footer {
      padding-top: var(--el-dialog-padding-primary);
      text-align: right;
      box-sizing: border-box
    }

    .el-dialog--center {
      text-align: center
    }

    .el-dialog--center .el-dialog__body {
      text-align: initial
    }

    .el-dialog--center .el-dialog__footer {
      text-align: inherit
    }

    .el-overlay-dialog {
      position: fixed;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      overflow: auto
    }

    .dialog-fade-enter-active {
      -webkit-animation: modal-fade-in var(--el-transition-duration);
      animation: modal-fade-in var(--el-transition-duration)
    }

    .dialog-fade-enter-active .el-overlay-dialog {
      -webkit-animation: dialog-fade-in var(--el-transition-duration);
      animation: dialog-fade-in var(--el-transition-duration)
    }

    .dialog-fade-leave-active {
      -webkit-animation: modal-fade-out var(--el-transition-duration);
      animation: modal-fade-out var(--el-transition-duration)
    }

    .dialog-fade-leave-active .el-overlay-dialog {
      -webkit-animation: dialog-fade-out var(--el-transition-duration);
      animation: dialog-fade-out var(--el-transition-duration)
    }

    @-webkit-keyframes dialog-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    @keyframes dialog-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    @-webkit-keyframes dialog-fade-out {
      0% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }

      100% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }
    }

    @keyframes dialog-fade-out {
      0% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }

      100% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }
    }

    @-webkit-keyframes modal-fade-in {
      0% {
        opacity: 0
      }

      100% {
        opacity: 1
      }
    }

    @keyframes modal-fade-in {
      0% {
        opacity: 0
      }

      100% {
        opacity: 1
      }
    }

    @-webkit-keyframes modal-fade-out {
      0% {
        opacity: 1
      }

      100% {
        opacity: 0
      }
    }

    @keyframes modal-fade-out {
      0% {
        opacity: 1
      }

      100% {
        opacity: 0
      }
    }

    .el-divider {
      position: relative
    }

    .el-divider--horizontal {
      display: block;
      height: 1px;
      width: 100%;
      margin: 24px 0;
      border-top: 1px var(--el-border-color) var(--el-border-style)
    }

    .el-divider--vertical {
      display: inline-block;
      width: 1px;
      height: 1em;
      margin: 0 8px;
      vertical-align: middle;
      position: relative;
      border-left: 1px var(--el-border-color) var(--el-border-style)
    }

    .el-divider__text {
      position: absolute;
      background-color: var(--el-bg-color);
      padding: 0 20px;
      font-weight: 500;
      color: var(--el-text-color-primary);
      font-size: 14px
    }

    .el-divider__text.is-left {
      left: 20px;
      transform: translateY(-50%)
    }

    .el-divider__text.is-center {
      left: 50%;
      transform: translateX(-50%) translateY(-50%)
    }

    .el-divider__text.is-right {
      right: 20px;
      transform: translateY(-50%)
    }

    .el-drawer {
      --el-drawer-bg-color: var(--el-dialog-bg-color, var(--el-bg-color));
      --el-drawer-padding-primary: var(--el-dialog-padding-primary, 20px)
    }

    .el-drawer {
      position: absolute;
      box-sizing: border-box;
      background-color: var(--el-drawer-bg-color);
      display: flex;
      flex-direction: column;
      box-shadow: var(--el-box-shadow-dark);
      overflow: hidden;
      transition: all var(--el-transition-duration)
    }

    .el-drawer .rtl {
      transform: translate(0, 0)
    }

    .el-drawer .ltr {
      transform: translate(0, 0)
    }

    .el-drawer .ttb {
      transform: translate(0, 0)
    }

    .el-drawer .btt {
      transform: translate(0, 0)
    }

    .el-drawer__sr-focus:focus {
      outline: 0 !important
    }

    .el-drawer__header {
      align-items: center;
      color: #72767b;
      display: flex;
      margin-bottom: 32px;
      padding: var(--el-drawer-padding-primary);
      padding-bottom: 0
    }

    .el-drawer__header>:first-child {
      flex: 1
    }

    .el-drawer__title {
      margin: 0;
      flex: 1;
      line-height: inherit;
      font-size: 1rem
    }

    .el-drawer__footer {
      padding: var(--el-drawer-padding-primary);
      padding-top: 10px;
      text-align: right
    }

    .el-drawer__close-btn {
      display: inline-flex;
      border: none;
      cursor: pointer;
      font-size: var(--el-font-size-extra-large);
      color: inherit;
      background-color: transparent;
      outline: 0
    }

    .el-drawer__close-btn:focus i,
    .el-drawer__close-btn:hover i {
      color: var(--el-color-primary)
    }

    .el-drawer__body {
      flex: 1;
      padding: var(--el-drawer-padding-primary);
      overflow: auto
    }

    .el-drawer__body>* {
      box-sizing: border-box
    }

    .el-drawer.ltr,
    .el-drawer.rtl {
      height: 100%;
      top: 0;
      bottom: 0
    }

    .el-drawer.btt,
    .el-drawer.ttb {
      width: 100%;
      left: 0;
      right: 0
    }

    .el-drawer.ltr {
      left: 0
    }

    .el-drawer.rtl {
      right: 0
    }

    .el-drawer.ttb {
      top: 0
    }

    .el-drawer.btt {
      bottom: 0
    }

    .el-drawer-fade-enter-active,
    .el-drawer-fade-leave-active {
      transition: all var(--el-transition-duration)
    }

    .el-drawer-fade-enter-active,
    .el-drawer-fade-enter-from,
    .el-drawer-fade-enter-to,
    .el-drawer-fade-leave-active,
    .el-drawer-fade-leave-from,
    .el-drawer-fade-leave-to {
      overflow: hidden !important
    }

    .el-drawer-fade-enter-from,
    .el-drawer-fade-leave-to {
      opacity: 0
    }

    .el-drawer-fade-enter-to,
    .el-drawer-fade-leave-from {
      opacity: 1
    }

    .el-drawer-fade-enter-from .rtl,
    .el-drawer-fade-leave-to .rtl {
      transform: translateX(100%)
    }

    .el-drawer-fade-enter-from .ltr,
    .el-drawer-fade-leave-to .ltr {
      transform: translateX(-100%)
    }

    .el-drawer-fade-enter-from .ttb,
    .el-drawer-fade-leave-to .ttb {
      transform: translateY(-100%)
    }

    .el-drawer-fade-enter-from .btt,
    .el-drawer-fade-leave-to .btt {
      transform: translateY(100%)
    }

    .el-dropdown {
      --el-dropdown-menu-box-shadow: var(--el-box-shadow-light);
      --el-dropdown-menuItem-hover-fill: var(--el-color-primary-light-9);
      --el-dropdown-menuItem-hover-color: var(--el-color-primary);
      --el-dropdown-menu-index: 10;
      display: inline-flex;
      position: relative;
      color: var(--el-text-color-regular);
      font-size: var(--el-font-size-base);
      line-height: 1;
      vertical-align: top
    }

    .el-dropdown.is-disabled {
      color: var(--el-text-color-placeholder);
      cursor: not-allowed
    }

    .el-dropdown__popper {
      --el-dropdown-menu-box-shadow: var(--el-box-shadow-light);
      --el-dropdown-menuItem-hover-fill: var(--el-color-primary-light-9);
      --el-dropdown-menuItem-hover-color: var(--el-color-primary);
      --el-dropdown-menu-index: 10
    }

    .el-dropdown__popper.el-popper {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-border-color-light);
      box-shadow: var(--el-dropdown-menu-box-shadow)
    }

    .el-dropdown__popper.el-popper .el-popper__arrow::before {
      border: 1px solid var(--el-border-color-light)
    }

    .el-dropdown__popper.el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-dropdown__popper.el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-dropdown__popper.el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-dropdown__popper.el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-dropdown__popper .el-dropdown-menu {
      border: none
    }

    .el-dropdown__popper .el-dropdown__popper-selfdefine {
      outline: 0
    }

    .el-dropdown__popper .el-scrollbar__bar {
      z-index: calc(var(--el-dropdown-menu-index) + 1)
    }

    .el-dropdown__popper .el-dropdown__list {
      list-style: none;
      padding: 0;
      margin: 0;
      box-sizing: border-box
    }

    .el-dropdown .el-dropdown__caret-button {
      padding-left: 0;
      padding-right: 0;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      width: 32px;
      border-left: none
    }

    .el-dropdown .el-dropdown__caret-button>span {
      display: inline-flex
    }

    .el-dropdown .el-dropdown__caret-button::before {
      content: """";
      position: absolute;
      display: block;
      width: 1px;
      top: -1px;
      bottom: -1px;
      left: 0;
      background: var(--el-overlay-color-lighter)
    }

    .el-dropdown .el-dropdown__caret-button.el-button::before {
      background: var(--el-border-color);
      opacity: .5
    }

    .el-dropdown .el-dropdown__caret-button .el-dropdown__icon {
      font-size: inherit;
      padding-left: 0
    }

    .el-dropdown .el-dropdown-selfdefine {
      outline: 0
    }

    .el-dropdown--large .el-dropdown__caret-button {
      width: 40px
    }

    .el-dropdown--small .el-dropdown__caret-button {
      width: 24px
    }

    .el-dropdown-menu {
      position: relative;
      top: 0;
      left: 0;
      z-index: var(--el-dropdown-menu-index);
      padding: 5px 0;
      margin: 0;
      background-color: var(--el-bg-color-overlay);
      border: none;
      border-radius: var(--el-border-radius-base);
      box-shadow: none;
      list-style: none
    }

    .el-dropdown-menu__item {
      display: flex;
      align-items: center;
      white-space: nowrap;
      list-style: none;
      line-height: 22px;
      padding: 5px 16px;
      margin: 0;
      font-size: var(--el-font-size-base);
      color: var(--el-text-color-regular);
      cursor: pointer;
      outline: 0
    }

    .el-dropdown-menu__item:not(.is-disabled):focus {
      background-color: var(--el-dropdown-menuItem-hover-fill);
      color: var(--el-dropdown-menuItem-hover-color)
    }

    .el-dropdown-menu__item i {
      margin-right: 5px
    }

    .el-dropdown-menu__item--divided {
      margin: 6px 0;
      border-top: 1px solid var(--el-border-color-lighter)
    }

    .el-dropdown-menu__item.is-disabled {
      cursor: not-allowed;
      color: var(--el-text-color-disabled)
    }

    .el-dropdown-menu--large {
      padding: 7px 0
    }

    .el-dropdown-menu--large .el-dropdown-menu__item {
      padding: 7px 20px;
      line-height: 22px;
      font-size: 14px
    }

    .el-dropdown-menu--large .el-dropdown-menu__item--divided {
      margin: 8px 0
    }

    .el-dropdown-menu--small {
      padding: 3px 0
    }

    .el-dropdown-menu--small .el-dropdown-menu__item {
      padding: 2px 12px;
      line-height: 20px;
      font-size: 12px
    }

    .el-dropdown-menu--small .el-dropdown-menu__item--divided {
      margin: 4px 0
    }

    .el-empty {
      --el-empty-padding: 40px 0;
      --el-empty-image-width: 160px;
      --el-empty-description-margin-top: 20px;
      --el-empty-bottom-margin-top: 20px;
      --el-empty-fill-color-0: var(--el-color-white);
      --el-empty-fill-color-1: #fcfcfd;
      --el-empty-fill-color-2: #f8f9fb;
      --el-empty-fill-color-3: #f7f8fc;
      --el-empty-fill-color-4: #eeeff3;
      --el-empty-fill-color-5: #edeef2;
      --el-empty-fill-color-6: #e9ebef;
      --el-empty-fill-color-7: #e5e7e9;
      --el-empty-fill-color-8: #e0e3e9;
      --el-empty-fill-color-9: #d5d7de;
      display: flex;
      justify-content: center;
      align-items: center;
      flex-direction: column;
      text-align: center;
      box-sizing: border-box;
      padding: var(--el-empty-padding)
    }

    .el-empty__image {
      width: var(--el-empty-image-width)
    }

    .el-empty__image img {
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      width: 100%;
      height: 100%;
      vertical-align: top;
      -o-object-fit: contain;
      object-fit: contain
    }

    .el-empty__image svg {
      color: var(--el-svg-monochrome-grey);
      fill: currentColor;
      width: 100%;
      height: 100%;
      vertical-align: top
    }

    .el-empty__description {
      margin-top: var(--el-empty-description-margin-top)
    }

    .el-empty__description p {
      margin: 0;
      font-size: var(--el-font-size-base);
      color: var(--el-text-color-secondary)
    }

    .el-empty__bottom {
      margin-top: var(--el-empty-bottom-margin-top)
    }

    .el-footer {
      --el-footer-padding: 0 20px;
      --el-footer-height: 60px;
      padding: var(--el-footer-padding);
      box-sizing: border-box;
      flex-shrink: 0;
      height: var(--el-footer-height)
    }

    .el-form {
      --el-form-label-font-size: var(--el-font-size-base);
      --el-form-inline-content-width: 220px
    }

    .el-form--label-left .el-form-item__label {
      justify-content: flex-start
    }

    .el-form--label-top .el-form-item {
      display: block
    }

    .el-form--label-top .el-form-item .el-form-item__label {
      display: block;
      height: auto;
      text-align: left;
      margin-bottom: 8px;
      line-height: 22px
    }

    .el-form--inline .el-form-item {
      display: inline-flex;
      vertical-align: middle;
      margin-right: 32px
    }

    .el-form--inline.el-form--label-top {
      display: flex;
      flex-wrap: wrap
    }

    .el-form--inline.el-form--label-top .el-form-item {
      display: block
    }

    .el-form--large.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 12px;
      line-height: 22px
    }

    .el-form--default.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 8px;
      line-height: 22px
    }

    .el-form--small.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 4px;
      line-height: 20px
    }

    .el-form-item {
      display: flex;
      --font-size: 14px;
      margin-bottom: 18px
    }

    .el-form-item .el-form-item {
      margin-bottom: 0
    }

    .el-form-item .el-input__validateIcon {
      display: none
    }

    .el-form-item--large {
      --font-size: 14px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 22px
    }

    .el-form-item--large .el-form-item__label {
      height: 40px;
      line-height: 40px
    }

    .el-form-item--large .el-form-item__content {
      line-height: 40px
    }

    .el-form-item--large .el-form-item__error {
      padding-top: 4px
    }

    .el-form-item--default {
      --font-size: 14px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 18px
    }

    .el-form-item--default .el-form-item__label {
      height: 32px;
      line-height: 32px
    }

    .el-form-item--default .el-form-item__content {
      line-height: 32px
    }

    .el-form-item--default .el-form-item__error {
      padding-top: 2px
    }

    .el-form-item--small {
      --font-size: 12px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 18px
    }

    .el-form-item--small .el-form-item__label {
      height: 24px;
      line-height: 24px
    }

    .el-form-item--small .el-form-item__content {
      line-height: 24px
    }

    .el-form-item--small .el-form-item__error {
      padding-top: 2px
    }

    .el-form-item__label-wrap {
      display: flex
    }

    .el-form-item__label {
      display: inline-flex;
      justify-content: flex-end;
      align-items: flex-start;
      flex: 0 0 auto;
      font-size: var(--el-form-label-font-size);
      color: var(--el-text-color-regular);
      height: 32px;
      line-height: 32px;
      padding: 0 12px 0 0;
      box-sizing: border-box
    }

    .el-form-item__content {
      display: flex;
      flex-wrap: wrap;
      align-items: center;
      flex: 1;
      line-height: 32px;
      position: relative;
      font-size: var(--font-size);
      min-width: 0
    }

    .el-form-item__content .el-input-group {
      vertical-align: top
    }

    .el-form-item__error {
      color: var(--el-color-danger);
      font-size: 12px;
      line-height: 1;
      padding-top: 2px;
      position: absolute;
      top: 100%;
      left: 0
    }

    .el-form-item__error--inline {
      position: relative;
      top: auto;
      left: auto;
      display: inline-block;
      margin-left: 10px
    }

    .el-form-item.is-required:not(.is-no-asterisk).asterisk-left>.el-form-item__label-wrap>.el-form-item__label:before,
    .el-form-item.is-required:not(.is-no-asterisk).asterisk-left>.el-form-item__label:before {
      content: ""*"";
      color: var(--el-color-danger);
      margin-right: 4px
    }

    .el-form-item.is-required:not(.is-no-asterisk).asterisk-right>.el-form-item__label-wrap>.el-form-item__label:after,
    .el-form-item.is-required:not(.is-no-asterisk).asterisk-right>.el-form-item__label:after {
      content: ""*"";
      color: var(--el-color-danger);
      margin-left: 4px
    }

    .el-form-item.is-error .el-input__wrapper,
    .el-form-item.is-error .el-input__wrapper.is-focus,
    .el-form-item.is-error .el-input__wrapper:focus,
    .el-form-item.is-error .el-input__wrapper:hover,
    .el-form-item.is-error .el-select__wrapper,
    .el-form-item.is-error .el-select__wrapper.is-focus,
    .el-form-item.is-error .el-select__wrapper:focus,
    .el-form-item.is-error .el-select__wrapper:hover,
    .el-form-item.is-error .el-textarea__inner,
    .el-form-item.is-error .el-textarea__inner.is-focus,
    .el-form-item.is-error .el-textarea__inner:focus,
    .el-form-item.is-error .el-textarea__inner:hover {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-form-item.is-error .el-input-group__append .el-input__wrapper,
    .el-form-item.is-error .el-input-group__prepend .el-input__wrapper {
      box-shadow: 0 0 0 1px transparent inset
    }

    .el-form-item.is-error .el-input__validateIcon {
      color: var(--el-color-danger)
    }

    .el-form-item--feedback .el-input__validateIcon {
      display: inline-flex
    }

    .el-header {
      --el-header-padding: 0 20px;
      --el-header-height: 60px;
      padding: var(--el-header-padding);
      box-sizing: border-box;
      flex-shrink: 0;
      height: var(--el-header-height)
    }

    .el-image-viewer__wrapper {
      position: fixed;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0
    }

    .el-image-viewer__btn {
      position: absolute;
      z-index: 1;
      display: flex;
      align-items: center;
      justify-content: center;
      border-radius: 50%;
      opacity: .8;
      cursor: pointer;
      box-sizing: border-box;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-image-viewer__btn .el-icon {
      font-size: inherit;
      cursor: pointer
    }

    .el-image-viewer__close {
      top: 40px;
      right: 40px;
      width: 40px;
      height: 40px;
      font-size: 40px
    }

    .el-image-viewer__canvas {
      position: static;
      width: 100%;
      height: 100%;
      display: flex;
      justify-content: center;
      align-items: center;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-image-viewer__actions {
      left: 50%;
      bottom: 30px;
      transform: translateX(-50%);
      width: 282px;
      height: 44px;
      padding: 0 23px;
      background-color: var(--el-text-color-regular);
      border-color: #fff;
      border-radius: 22px
    }

    .el-image-viewer__actions__inner {
      width: 100%;
      height: 100%;
      cursor: default;
      font-size: 23px;
      color: #fff;
      display: flex;
      align-items: center;
      justify-content: space-around
    }

    .el-image-viewer__prev {
      top: 50%;
      transform: translateY(-50%);
      left: 40px;
      width: 44px;
      height: 44px;
      font-size: 24px;
      color: #fff;
      background-color: var(--el-text-color-regular);
      border-color: #fff
    }

    .el-image-viewer__next {
      top: 50%;
      transform: translateY(-50%);
      right: 40px;
      text-indent: 2px;
      width: 44px;
      height: 44px;
      font-size: 24px;
      color: #fff;
      background-color: var(--el-text-color-regular);
      border-color: #fff
    }

    .el-image-viewer__close {
      width: 44px;
      height: 44px;
      font-size: 24px;
      color: #fff;
      background-color: var(--el-text-color-regular);
      border-color: #fff
    }

    .el-image-viewer__mask {
      position: absolute;
      width: 100%;
      height: 100%;
      top: 0;
      left: 0;
      opacity: .5;
      background: #000
    }

    .viewer-fade-enter-active {
      -webkit-animation: viewer-fade-in var(--el-transition-duration);
      animation: viewer-fade-in var(--el-transition-duration)
    }

    .viewer-fade-leave-active {
      -webkit-animation: viewer-fade-out var(--el-transition-duration);
      animation: viewer-fade-out var(--el-transition-duration)
    }

    @-webkit-keyframes viewer-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    @keyframes viewer-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    @-webkit-keyframes viewer-fade-out {
      0% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }

      100% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }
    }

    @keyframes viewer-fade-out {
      0% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }

      100% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }
    }

    .el-image__error,
    .el-image__inner,
    .el-image__placeholder,
    .el-image__wrapper {
      width: 100%;
      height: 100%
    }

    .el-image {
      position: relative;
      display: inline-block;
      overflow: hidden
    }

    .el-image__inner {
      vertical-align: top;
      opacity: 1
    }

    .el-image__inner.is-loading {
      opacity: 0
    }

    .el-image__wrapper {
      position: absolute;
      top: 0;
      left: 0
    }

    .el-image__placeholder {
      background: var(--el-fill-color-light)
    }

    .el-image__error {
      display: flex;
      justify-content: center;
      align-items: center;
      font-size: 14px;
      background: var(--el-fill-color-light);
      color: var(--el-text-color-placeholder);
      vertical-align: middle
    }

    .el-image__preview {
      cursor: pointer
    }

    .el-input-number {
      position: relative;
      display: inline-flex;
      width: 150px;
      line-height: 30px
    }

    .el-input-number .el-input__wrapper {
      padding-left: 42px;
      padding-right: 42px
    }

    .el-input-number .el-input__inner {
      -webkit-appearance: none;
      -moz-appearance: textfield;
      text-align: center;
      line-height: 1
    }

    .el-input-number .el-input__inner::-webkit-inner-spin-button,
    .el-input-number .el-input__inner::-webkit-outer-spin-button {
      margin: 0;
      -webkit-appearance: none
    }

    .el-input-number__decrease,
    .el-input-number__increase {
      display: flex;
      justify-content: center;
      align-items: center;
      height: auto;
      position: absolute;
      z-index: 1;
      top: 1px;
      bottom: 1px;
      width: 32px;
      background: var(--el-fill-color-light);
      color: var(--el-text-color-regular);
      cursor: pointer;
      font-size: 13px;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-input-number__decrease:hover,
    .el-input-number__increase:hover {
      color: var(--el-color-primary)
    }

    .el-input-number__decrease:hover~.el-input:not(.is-disabled) .el-input__wrapper,
    .el-input-number__increase:hover~.el-input:not(.is-disabled) .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color, var(--el-color-primary)) inset
    }

    .el-input-number__decrease.is-disabled,
    .el-input-number__increase.is-disabled {
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-input-number__increase {
      right: 1px;
      border-radius: 0 var(--el-border-radius-base) var(--el-border-radius-base) 0;
      border-left: var(--el-border)
    }

    .el-input-number__decrease {
      left: 1px;
      border-radius: var(--el-border-radius-base) 0 0 var(--el-border-radius-base);
      border-right: var(--el-border)
    }

    .el-input-number.is-disabled .el-input-number__decrease,
    .el-input-number.is-disabled .el-input-number__increase {
      border-color: var(--el-disabled-border-color);
      color: var(--el-disabled-border-color)
    }

    .el-input-number.is-disabled .el-input-number__decrease:hover,
    .el-input-number.is-disabled .el-input-number__increase:hover {
      color: var(--el-disabled-border-color);
      cursor: not-allowed
    }

    .el-input-number--large {
      width: 180px;
      line-height: 38px
    }

    .el-input-number--large .el-input-number__decrease,
    .el-input-number--large .el-input-number__increase {
      width: 40px;
      font-size: 14px
    }

    .el-input-number--large .el-input__wrapper {
      padding-left: 47px;
      padding-right: 47px
    }

    .el-input-number--small {
      width: 120px;
      line-height: 22px
    }

    .el-input-number--small .el-input-number__decrease,
    .el-input-number--small .el-input-number__increase {
      width: 24px;
      font-size: 12px
    }

    .el-input-number--small .el-input__wrapper {
      padding-left: 31px;
      padding-right: 31px
    }

    .el-input-number--small .el-input-number__decrease [class*=el-icon],
    .el-input-number--small .el-input-number__increase [class*=el-icon] {
      transform: scale(.9)
    }

    .el-input-number.is-without-controls .el-input__wrapper {
      padding-left: 15px;
      padding-right: 15px
    }

    .el-input-number.is-controls-right .el-input__wrapper {
      padding-left: 15px;
      padding-right: 42px
    }

    .el-input-number.is-controls-right .el-input-number__decrease,
    .el-input-number.is-controls-right .el-input-number__increase {
      --el-input-number-controls-height: 15px;
      height: var(--el-input-number-controls-height);
      line-height: var(--el-input-number-controls-height)
    }

    .el-input-number.is-controls-right .el-input-number__decrease [class*=el-icon],
    .el-input-number.is-controls-right .el-input-number__increase [class*=el-icon] {
      transform: scale(.8)
    }

    .el-input-number.is-controls-right .el-input-number__increase {
      bottom: auto;
      left: auto;
      border-radius: 0 var(--el-border-radius-base) 0 0;
      border-bottom: var(--el-border)
    }

    .el-input-number.is-controls-right .el-input-number__decrease {
      right: 1px;
      top: auto;
      left: auto;
      border-right: none;
      border-left: var(--el-border);
      border-radius: 0 0 var(--el-border-radius-base) 0
    }

    .el-input-number.is-controls-right[class*=large] [class*=decrease],
    .el-input-number.is-controls-right[class*=large] [class*=increase] {
      --el-input-number-controls-height: 19px
    }

    .el-input-number.is-controls-right[class*=small] [class*=decrease],
    .el-input-number.is-controls-right[class*=small] [class*=increase] {
      --el-input-number-controls-height: 11px
    }

    .el-textarea {
      --el-input-text-color: var(--el-text-color-regular);
      --el-input-border: var(--el-border);
      --el-input-hover-border: var(--el-border-color-hover);
      --el-input-focus-border: var(--el-color-primary);
      --el-input-transparent-border: 0 0 0 1px transparent inset;
      --el-input-border-color: var(--el-border-color);
      --el-input-border-radius: var(--el-border-radius-base);
      --el-input-bg-color: var(--el-fill-color-blank);
      --el-input-icon-color: var(--el-text-color-placeholder);
      --el-input-placeholder-color: var(--el-text-color-placeholder);
      --el-input-hover-border-color: var(--el-border-color-hover);
      --el-input-clear-hover-color: var(--el-text-color-secondary);
      --el-input-focus-border-color: var(--el-color-primary);
      --el-input-width: 100%
    }

    .el-textarea {
      position: relative;
      display: inline-block;
      width: 100%;
      vertical-align: bottom;
      font-size: var(--el-font-size-base)
    }

    .el-textarea__inner {
      position: relative;
      display: block;
      resize: vertical;
      padding: 5px 11px;
      line-height: 1.5;
      box-sizing: border-box;
      width: 100%;
      font-size: inherit;
      font-family: inherit;
      color: var(--el-input-text-color, var(--el-text-color-regular));
      background-color: var(--el-input-bg-color, var(--el-fill-color-blank));
      background-image: none;
      -webkit-appearance: none;
      box-shadow: 0 0 0 1px var(--el-input-border-color, var(--el-border-color)) inset;
      border-radius: var(--el-input-border-radius, var(--el-border-radius-base));
      transition: var(--el-transition-box-shadow);
      border: none
    }

    .el-textarea__inner::-moz-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner:-ms-input-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner::placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner:hover {
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-textarea__inner:focus {
      outline: 0;
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-textarea .el-input__count {
      color: var(--el-color-info);
      background: var(--el-fill-color-blank);
      position: absolute;
      font-size: 12px;
      line-height: 14px;
      bottom: 5px;
      right: 10px
    }

    .el-textarea.is-disabled .el-textarea__inner {
      box-shadow: 0 0 0 1px var(--el-disabled-border-color) inset;
      background-color: var(--el-disabled-bg-color);
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-textarea.is-disabled .el-textarea__inner::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-disabled .el-textarea__inner:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-disabled .el-textarea__inner::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-exceed .el-textarea__inner {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-textarea.is-exceed .el-input__count {
      color: var(--el-color-danger)
    }

    .el-input {
      --el-input-text-color: var(--el-text-color-regular);
      --el-input-border: var(--el-border);
      --el-input-hover-border: var(--el-border-color-hover);
      --el-input-focus-border: var(--el-color-primary);
      --el-input-transparent-border: 0 0 0 1px transparent inset;
      --el-input-border-color: var(--el-border-color);
      --el-input-border-radius: var(--el-border-radius-base);
      --el-input-bg-color: var(--el-fill-color-blank);
      --el-input-icon-color: var(--el-text-color-placeholder);
      --el-input-placeholder-color: var(--el-text-color-placeholder);
      --el-input-hover-border-color: var(--el-border-color-hover);
      --el-input-clear-hover-color: var(--el-text-color-secondary);
      --el-input-focus-border-color: var(--el-color-primary);
      --el-input-width: 100%
    }

    .el-input {
      --el-input-height: var(--el-component-size);
      position: relative;
      font-size: var(--el-font-size-base);
      display: inline-flex;
      width: var(--el-input-width);
      line-height: var(--el-input-height);
      box-sizing: border-box;
      vertical-align: middle
    }

    .el-input::-webkit-scrollbar {
      z-index: 11;
      width: 6px
    }

    .el-input::-webkit-scrollbar:horizontal {
      height: 6px
    }

    .el-input::-webkit-scrollbar-thumb {
      border-radius: 5px;
      width: 6px;
      background: var(--el-text-color-disabled)
    }

    .el-input::-webkit-scrollbar-corner {
      background: var(--el-fill-color-blank)
    }

    .el-input::-webkit-scrollbar-track {
      background: var(--el-fill-color-blank)
    }

    .el-input::-webkit-scrollbar-track-piece {
      background: var(--el-fill-color-blank);
      width: 6px
    }

    .el-input .el-input__clear,
    .el-input .el-input__password {
      color: var(--el-input-icon-color);
      font-size: 14px;
      cursor: pointer
    }

    .el-input .el-input__clear:hover,
    .el-input .el-input__password:hover {
      color: var(--el-input-clear-hover-color)
    }

    .el-input .el-input__count {
      height: 100%;
      display: inline-flex;
      align-items: center;
      color: var(--el-color-info);
      font-size: 12px
    }

    .el-input .el-input__count .el-input__count-inner {
      background: var(--el-fill-color-blank);
      line-height: initial;
      display: inline-block;
      padding-left: 8px
    }

    .el-input__wrapper {
      display: inline-flex;
      flex-grow: 1;
      align-items: center;
      justify-content: center;
      padding: 1px 11px;
      background-color: var(--el-input-bg-color, var(--el-fill-color-blank));
      background-image: none;
      border-radius: var(--el-input-border-radius, var(--el-border-radius-base));
      cursor: text;
      transition: var(--el-transition-box-shadow);
      transform: translate3d(0, 0, 0);
      box-shadow: 0 0 0 1px var(--el-input-border-color, var(--el-border-color)) inset
    }

    .el-input__wrapper:hover {
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-input__wrapper.is-focus {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 32px) - 2px);
      width: 100%;
      flex-grow: 1;
      -webkit-appearance: none;
      color: var(--el-input-text-color, var(--el-text-color-regular));
      font-size: inherit;
      height: var(--el-input-inner-height);
      line-height: var(--el-input-inner-height);
      padding: 0;
      outline: 0;
      border: none;
      background: 0 0;
      box-sizing: border-box
    }

    .el-input__inner:focus {
      outline: 0
    }

    .el-input__inner::-moz-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner:-ms-input-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner::placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner[type=password]::-ms-reveal {
      display: none
    }

    .el-input__inner[type=number] {
      line-height: 1
    }

    .el-input__prefix {
      display: inline-flex;
      white-space: nowrap;
      flex-shrink: 0;
      flex-wrap: nowrap;
      height: 100%;
      text-align: center;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder));
      transition: all var(--el-transition-duration);
      pointer-events: none
    }

    .el-input__prefix-inner {
      pointer-events: all;
      display: inline-flex;
      align-items: center;
      justify-content: center
    }

    .el-input__prefix-inner>:last-child {
      margin-right: 8px
    }

    .el-input__prefix-inner>:first-child,
    .el-input__prefix-inner>:first-child.el-input__icon {
      margin-left: 0
    }

    .el-input__suffix {
      display: inline-flex;
      white-space: nowrap;
      flex-shrink: 0;
      flex-wrap: nowrap;
      height: 100%;
      text-align: center;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder));
      transition: all var(--el-transition-duration);
      pointer-events: none
    }

    .el-input__suffix-inner {
      pointer-events: all;
      display: inline-flex;
      align-items: center;
      justify-content: center
    }

    .el-input__suffix-inner>:first-child {
      margin-left: 8px
    }

    .el-input .el-input__icon {
      height: inherit;
      line-height: inherit;
      display: flex;
      justify-content: center;
      align-items: center;
      transition: all var(--el-transition-duration);
      margin-left: 8px
    }

    .el-input__validateIcon {
      pointer-events: none
    }

    .el-input.is-active .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-input-focus-color, ) inset
    }

    .el-input.is-disabled {
      cursor: not-allowed
    }

    .el-input.is-disabled .el-input__wrapper {
      background-color: var(--el-disabled-bg-color);
      box-shadow: 0 0 0 1px var(--el-disabled-border-color) inset
    }

    .el-input.is-disabled .el-input__inner {
      color: var(--el-disabled-text-color);
      -webkit-text-fill-color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-input.is-disabled .el-input__inner::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__inner:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__inner::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__icon {
      cursor: not-allowed
    }

    .el-input.is-exceed .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-input.is-exceed .el-input__suffix .el-input__count {
      color: var(--el-color-danger)
    }

    .el-input--large {
      --el-input-height: var(--el-component-size-large);
      font-size: 14px
    }

    .el-input--large .el-input__wrapper {
      padding: 1px 15px
    }

    .el-input--large .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 40px) - 2px)
    }

    .el-input--small {
      --el-input-height: var(--el-component-size-small);
      font-size: 12px
    }

    .el-input--small .el-input__wrapper {
      padding: 1px 7px
    }

    .el-input--small .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 24px) - 2px)
    }

    .el-input-group {
      display: inline-flex;
      width: 100%;
      align-items: stretch
    }

    .el-input-group__append,
    .el-input-group__prepend {
      background-color: var(--el-fill-color-light);
      color: var(--el-color-info);
      position: relative;
      display: inline-flex;
      align-items: center;
      justify-content: center;
      min-height: 100%;
      border-radius: var(--el-input-border-radius);
      padding: 0 20px;
      white-space: nowrap
    }

    .el-input-group__append:focus,
    .el-input-group__prepend:focus {
      outline: 0
    }

    .el-input-group__append .el-button,
    .el-input-group__append .el-select,
    .el-input-group__prepend .el-button,
    .el-input-group__prepend .el-select {
      display: inline-block;
      margin: 0 -20px
    }

    .el-input-group__append button.el-button,
    .el-input-group__append button.el-button:hover,
    .el-input-group__append div.el-select .el-select__wrapper,
    .el-input-group__append div.el-select:hover .el-select__wrapper,
    .el-input-group__prepend button.el-button,
    .el-input-group__prepend button.el-button:hover,
    .el-input-group__prepend div.el-select .el-select__wrapper,
    .el-input-group__prepend div.el-select:hover .el-select__wrapper {
      border-color: transparent;
      background-color: transparent;
      color: inherit
    }

    .el-input-group__append .el-button,
    .el-input-group__append .el-input,
    .el-input-group__prepend .el-button,
    .el-input-group__prepend .el-input {
      font-size: inherit
    }

    .el-input-group__prepend {
      border-right: 0;
      border-top-right-radius: 0;
      border-bottom-right-radius: 0;
      box-shadow: 1px 0 0 0 var(--el-input-border-color) inset, 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset
    }

    .el-input-group__append {
      border-left: 0;
      border-top-left-radius: 0;
      border-bottom-left-radius: 0;
      box-shadow: 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset, -1px 0 0 0 var(--el-input-border-color) inset
    }

    .el-input-group--prepend>.el-input__wrapper {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0
    }

    .el-input-group--prepend .el-input-group__prepend .el-select .el-select__wrapper {
      border-top-right-radius: 0;
      border-bottom-right-radius: 0;
      box-shadow: 1px 0 0 0 var(--el-input-border-color) inset, 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset
    }

    .el-input-group--append>.el-input__wrapper {
      border-top-right-radius: 0;
      border-bottom-right-radius: 0
    }

    .el-input-group--append .el-input-group__append .el-select .el-select__wrapper {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0;
      box-shadow: 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset, -1px 0 0 0 var(--el-input-border-color) inset
    }

    .el-link {
      --el-link-font-size: var(--el-font-size-base);
      --el-link-font-weight: var(--el-font-weight-primary);
      --el-link-text-color: var(--el-text-color-regular);
      --el-link-hover-text-color: var(--el-color-primary);
      --el-link-disabled-text-color: var(--el-text-color-placeholder)
    }

    .el-link {
      display: inline-flex;
      flex-direction: row;
      align-items: center;
      justify-content: center;
      vertical-align: middle;
      position: relative;
      text-decoration: none;
      outline: 0;
      cursor: pointer;
      padding: 0;
      font-size: var(--el-link-font-size);
      font-weight: var(--el-link-font-weight);
      color: var(--el-link-text-color)
    }

    .el-link:hover {
      color: var(--el-link-hover-text-color)
    }

    .el-link.is-underline:hover:after {
      content: """";
      position: absolute;
      left: 0;
      right: 0;
      height: 0;
      bottom: 0;
      border-bottom: 1px solid var(--el-link-hover-text-color)
    }

    .el-link.is-disabled {
      color: var(--el-link-disabled-text-color);
      cursor: not-allowed
    }

    .el-link [class*=el-icon-]+span {
      margin-left: 5px
    }

    .el-link.el-link--default:after {
      border-color: var(--el-link-hover-text-color)
    }

    .el-link__inner {
      display: inline-flex;
      justify-content: center;
      align-items: center
    }

    .el-link.el-link--primary {
      --el-link-text-color: var(--el-color-primary);
      --el-link-hover-text-color: var(--el-color-primary-light-3);
      --el-link-disabled-text-color: var(--el-color-primary-light-5)
    }

    .el-link.el-link--primary:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--primary.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--success {
      --el-link-text-color: var(--el-color-success);
      --el-link-hover-text-color: var(--el-color-success-light-3);
      --el-link-disabled-text-color: var(--el-color-success-light-5)
    }

    .el-link.el-link--success:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--success.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--warning {
      --el-link-text-color: var(--el-color-warning);
      --el-link-hover-text-color: var(--el-color-warning-light-3);
      --el-link-disabled-text-color: var(--el-color-warning-light-5)
    }

    .el-link.el-link--warning:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--warning.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--danger {
      --el-link-text-color: var(--el-color-danger);
      --el-link-hover-text-color: var(--el-color-danger-light-3);
      --el-link-disabled-text-color: var(--el-color-danger-light-5)
    }

    .el-link.el-link--danger:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--danger.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--error {
      --el-link-text-color: var(--el-color-error);
      --el-link-hover-text-color: var(--el-color-error-light-3);
      --el-link-disabled-text-color: var(--el-color-error-light-5)
    }

    .el-link.el-link--error:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--error.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--info {
      --el-link-text-color: var(--el-color-info);
      --el-link-hover-text-color: var(--el-color-info-light-3);
      --el-link-disabled-text-color: var(--el-color-info-light-5)
    }

    .el-link.el-link--info:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--info.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    :root {
      --el-loading-spinner-size: 42px;
      --el-loading-fullscreen-spinner-size: 50px
    }

    .el-loading-parent--relative {
      position: relative !important
    }

    .el-loading-parent--hidden {
      overflow: hidden !important
    }

    .el-loading-mask {
      position: absolute;
      z-index: 2000;
      background-color: var(--el-mask-color);
      margin: 0;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      transition: opacity var(--el-transition-duration)
    }

    .el-loading-mask.is-fullscreen {
      position: fixed
    }

    .el-loading-mask.is-fullscreen .el-loading-spinner {
      margin-top: calc((0px - var(--el-loading-fullscreen-spinner-size))/ 2)
    }

    .el-loading-mask.is-fullscreen .el-loading-spinner .circular {
      height: var(--el-loading-fullscreen-spinner-size);
      width: var(--el-loading-fullscreen-spinner-size)
    }

    .el-loading-spinner {
      top: 50%;
      margin-top: calc((0px - var(--el-loading-spinner-size))/ 2);
      width: 100%;
      text-align: center;
      position: absolute
    }

    .el-loading-spinner .el-loading-text {
      color: var(--el-color-primary);
      margin: 3px 0;
      font-size: 14px
    }

    .el-loading-spinner .circular {
      display: inline;
      height: var(--el-loading-spinner-size);
      width: var(--el-loading-spinner-size);
      -webkit-animation: loading-rotate 2s linear infinite;
      animation: loading-rotate 2s linear infinite
    }

    .el-loading-spinner .path {
      -webkit-animation: loading-dash 1.5s ease-in-out infinite;
      animation: loading-dash 1.5s ease-in-out infinite;
      stroke-dasharray: 90, 150;
      stroke-dashoffset: 0;
      stroke-width: 2;
      stroke: var(--el-color-primary);
      stroke-linecap: round
    }

    .el-loading-spinner i {
      color: var(--el-color-primary)
    }

    .el-loading-fade-enter-from,
    .el-loading-fade-leave-to {
      opacity: 0
    }

    @-webkit-keyframes loading-rotate {
      100% {
        transform: rotate(360deg)
      }
    }

    @keyframes loading-rotate {
      100% {
        transform: rotate(360deg)
      }
    }

    @-webkit-keyframes loading-dash {
      0% {
        stroke-dasharray: 1, 200;
        stroke-dashoffset: 0
      }

      50% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -40px
      }

      100% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -120px
      }
    }

    @keyframes loading-dash {
      0% {
        stroke-dasharray: 1, 200;
        stroke-dashoffset: 0
      }

      50% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -40px
      }

      100% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -120px
      }
    }

    .el-main {
      --el-main-padding: 20px;
      display: block;
      flex: 1;
      flex-basis: auto;
      overflow: auto;
      box-sizing: border-box;
      padding: var(--el-main-padding)
    }

    :root {
      --el-menu-active-color: var(--el-color-primary);
      --el-menu-text-color: var(--el-text-color-primary);
      --el-menu-hover-text-color: var(--el-color-primary);
      --el-menu-bg-color: var(--el-fill-color-blank);
      --el-menu-hover-bg-color: var(--el-color-primary-light-9);
      --el-menu-item-height: 56px;
      --el-menu-sub-item-height: calc(var(--el-menu-item-height) - 6px);
      --el-menu-horizontal-height: 60px;
      --el-menu-horizontal-sub-item-height: 36px;
      --el-menu-item-font-size: var(--el-font-size-base);
      --el-menu-item-hover-fill: var(--el-color-primary-light-9);
      --el-menu-border-color: var(--el-border-color);
      --el-menu-base-level-padding: 20px;
      --el-menu-level-padding: 20px;
      --el-menu-icon-width: 24px
    }

    .el-menu {
      border-right: solid 1px var(--el-menu-border-color);
      list-style: none;
      position: relative;
      margin: 0;
      padding-left: 0;
      background-color: var(--el-menu-bg-color);
      box-sizing: border-box
    }

    .el-menu--vertical:not(.el-menu--collapse):not(.el-menu--popup-container) .el-menu-item,
    .el-menu--vertical:not(.el-menu--collapse):not(.el-menu--popup-container) .el-menu-item-group__title,
    .el-menu--vertical:not(.el-menu--collapse):not(.el-menu--popup-container) .el-sub-menu__title {
      white-space: nowrap;
      padding-left: calc(var(--el-menu-base-level-padding) + var(--el-menu-level) * var(--el-menu-level-padding))
    }

    .el-menu:not(.el-menu--collapse) .el-sub-menu__title {
      padding-right: calc(var(--el-menu-base-level-padding) + var(--el-menu-icon-width))
    }

    .el-menu--horizontal {
      display: flex;
      flex-wrap: nowrap;
      border-right: none;
      height: var(--el-menu-horizontal-height)
    }

    .el-menu--horizontal.el-menu--popup-container {
      height: unset
    }

    .el-menu--horizontal.el-menu {
      border-bottom: solid 1px var(--el-menu-border-color)
    }

    .el-menu--horizontal>.el-menu-item {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      height: 100%;
      margin: 0;
      border-bottom: 2px solid transparent;
      color: var(--el-menu-text-color)
    }

    .el-menu--horizontal>.el-menu-item a,
    .el-menu--horizontal>.el-menu-item a:hover {
      color: inherit
    }

    .el-menu--horizontal>.el-sub-menu:focus,
    .el-menu--horizontal>.el-sub-menu:hover {
      outline: 0
    }

    .el-menu--horizontal>.el-sub-menu:hover .el-sub-menu__title {
      color: var(--el-menu-hover-text-color)
    }

    .el-menu--horizontal>.el-sub-menu.is-active .el-sub-menu__title {
      border-bottom: 2px solid var(--el-menu-active-color);
      color: var(--el-menu-active-color)
    }

    .el-menu--horizontal>.el-sub-menu .el-sub-menu__title {
      height: 100%;
      border-bottom: 2px solid transparent;
      color: var(--el-menu-text-color)
    }

    .el-menu--horizontal>.el-sub-menu .el-sub-menu__title:hover {
      background-color: var(--el-menu-bg-color)
    }

    .el-menu--horizontal .el-menu .el-menu-item,
    .el-menu--horizontal .el-menu .el-sub-menu__title {
      background-color: var(--el-menu-bg-color);
      display: flex;
      align-items: center;
      height: var(--el-menu-horizontal-sub-item-height);
      line-height: var(--el-menu-horizontal-sub-item-height);
      padding: 0 10px;
      color: var(--el-menu-text-color)
    }

    .el-menu--horizontal .el-menu .el-sub-menu__title {
      padding-right: 40px
    }

    .el-menu--horizontal .el-menu .el-menu-item.is-active,
    .el-menu--horizontal .el-menu .el-sub-menu.is-active>.el-sub-menu__title {
      color: var(--el-menu-active-color)
    }

    .el-menu--horizontal .el-menu-item:not(.is-disabled):focus,
    .el-menu--horizontal .el-menu-item:not(.is-disabled):hover {
      outline: 0;
      color: var(--el-menu-hover-text-color);
      background-color: var(--el-menu-hover-bg-color)
    }

    .el-menu--horizontal>.el-menu-item.is-active {
      border-bottom: 2px solid var(--el-menu-active-color);
      color: var(--el-menu-active-color) !important
    }

    .el-menu--collapse {
      width: calc(var(--el-menu-icon-width) + var(--el-menu-base-level-padding) * 2)
    }

    .el-menu--collapse>.el-menu-item [class^=el-icon],
    .el-menu--collapse>.el-menu-item-group>ul>.el-sub-menu>.el-sub-menu__title [class^=el-icon],
    .el-menu--collapse>.el-sub-menu>.el-sub-menu__title [class^=el-icon] {
      margin: 0;
      vertical-align: middle;
      width: var(--el-menu-icon-width);
      text-align: center
    }

    .el-menu--collapse>.el-menu-item .el-sub-menu__icon-arrow,
    .el-menu--collapse>.el-menu-item-group>ul>.el-sub-menu>.el-sub-menu__title .el-sub-menu__icon-arrow,
    .el-menu--collapse>.el-sub-menu>.el-sub-menu__title .el-sub-menu__icon-arrow {
      display: none
    }

    .el-menu--collapse>.el-menu-item-group>ul>.el-sub-menu>.el-sub-menu__title>span,
    .el-menu--collapse>.el-menu-item>span,
    .el-menu--collapse>.el-sub-menu>.el-sub-menu__title>span {
      height: 0;
      width: 0;
      overflow: hidden;
      visibility: hidden;
      display: inline-block
    }

    .el-menu--collapse>.el-menu-item.is-active i {
      color: inherit
    }

    .el-menu--collapse .el-menu .el-sub-menu {
      min-width: 200px
    }

    .el-menu--collapse .el-sub-menu.is-active .el-sub-menu__title {
      color: var(--el-menu-active-color)
    }

    .el-menu--popup {
      z-index: 100;
      min-width: 200px;
      border: none;
      padding: 5px 0;
      border-radius: var(--el-border-radius-small);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-menu .el-icon {
      flex-shrink: 0
    }

    .el-menu-item {
      display: flex;
      align-items: center;
      height: var(--el-menu-item-height);
      line-height: var(--el-menu-item-height);
      font-size: var(--el-menu-item-font-size);
      color: var(--el-menu-text-color);
      padding: 0 var(--el-menu-base-level-padding);
      list-style: none;
      cursor: pointer;
      position: relative;
      transition: border-color var(--el-transition-duration), background-color var(--el-transition-duration), color var(--el-transition-duration);
      box-sizing: border-box;
      white-space: nowrap
    }

    .el-menu-item * {
      vertical-align: bottom
    }

    .el-menu-item i {
      color: inherit
    }

    .el-menu-item:focus,
    .el-menu-item:hover {
      outline: 0
    }

    .el-menu-item:hover {
      background-color: var(--el-menu-hover-bg-color)
    }

    .el-menu-item.is-disabled {
      opacity: .25;
      cursor: not-allowed;
      background: 0 0 !important
    }

    .el-menu-item [class^=el-icon] {
      margin-right: 5px;
      width: var(--el-menu-icon-width);
      text-align: center;
      font-size: 18px;
      vertical-align: middle
    }

    .el-menu-item.is-active {
      color: var(--el-menu-active-color)
    }

    .el-menu-item.is-active i {
      color: inherit
    }

    .el-menu-item .el-menu-tooltip__trigger {
      position: absolute;
      left: 0;
      top: 0;
      height: 100%;
      width: 100%;
      display: inline-flex;
      align-items: center;
      box-sizing: border-box;
      padding: 0 var(--el-menu-base-level-padding)
    }

    .el-sub-menu {
      list-style: none;
      margin: 0;
      padding-left: 0
    }

    .el-sub-menu__title {
      display: flex;
      align-items: center;
      height: var(--el-menu-item-height);
      line-height: var(--el-menu-item-height);
      font-size: var(--el-menu-item-font-size);
      color: var(--el-menu-text-color);
      padding: 0 var(--el-menu-base-level-padding);
      list-style: none;
      cursor: pointer;
      position: relative;
      transition: border-color var(--el-transition-duration), background-color var(--el-transition-duration), color var(--el-transition-duration);
      box-sizing: border-box;
      white-space: nowrap
    }

    .el-sub-menu__title * {
      vertical-align: bottom
    }

    .el-sub-menu__title i {
      color: inherit
    }

    .el-sub-menu__title:focus,
    .el-sub-menu__title:hover {
      outline: 0
    }

    .el-sub-menu__title:hover {
      background-color: var(--el-menu-hover-bg-color)
    }

    .el-sub-menu__title.is-disabled {
      opacity: .25;
      cursor: not-allowed;
      background: 0 0 !important
    }

    .el-sub-menu__title:hover {
      background-color: var(--el-menu-hover-bg-color)
    }

    .el-sub-menu .el-menu {
      border: none
    }

    .el-sub-menu .el-menu-item {
      height: var(--el-menu-sub-item-height);
      line-height: var(--el-menu-sub-item-height)
    }

    .el-sub-menu__hide-arrow .el-sub-menu__icon-arrow {
      display: none !important
    }

    .el-sub-menu.is-active .el-sub-menu__title {
      border-bottom-color: var(--el-menu-active-color)
    }

    .el-sub-menu.is-disabled .el-menu-item,
    .el-sub-menu.is-disabled .el-sub-menu__title {
      opacity: .25;
      cursor: not-allowed;
      background: 0 0 !important
    }

    .el-sub-menu .el-icon {
      vertical-align: middle;
      margin-right: 5px;
      width: var(--el-menu-icon-width);
      text-align: center;
      font-size: 18px
    }

    .el-sub-menu .el-icon.el-sub-menu__icon-more {
      margin-right: 0 !important
    }

    .el-sub-menu .el-sub-menu__icon-arrow {
      position: absolute;
      top: 50%;
      right: var(--el-menu-base-level-padding);
      margin-top: -6px;
      transition: transform var(--el-transition-duration);
      font-size: 12px;
      margin-right: 0;
      width: inherit
    }

    .el-menu-item-group>ul {
      padding: 0
    }

    .el-menu-item-group__title {
      padding: 7px 0 7px var(--el-menu-base-level-padding);
      line-height: normal;
      font-size: 12px;
      color: var(--el-text-color-secondary)
    }

    .horizontal-collapse-transition .el-sub-menu__title .el-sub-menu__icon-arrow {
      transition: var(--el-transition-duration-fast);
      opacity: 0
    }

    .el-message-box {
      --el-messagebox-title-color: var(--el-text-color-primary);
      --el-messagebox-width: 420px;
      --el-messagebox-border-radius: 4px;
      --el-messagebox-box-shadow: var(--el-box-shadow);
      --el-messagebox-font-size: var(--el-font-size-large);
      --el-messagebox-content-font-size: var(--el-font-size-base);
      --el-messagebox-content-color: var(--el-text-color-regular);
      --el-messagebox-error-font-size: 12px;
      --el-messagebox-padding-primary: 12px;
      --el-messagebox-font-line-height: var(--el-font-line-height-primary)
    }

    .el-message-box {
      display: inline-block;
      position: relative;
      max-width: var(--el-messagebox-width);
      width: 100%;
      padding: var(--el-messagebox-padding-primary);
      vertical-align: middle;
      background-color: var(--el-bg-color);
      border-radius: var(--el-messagebox-border-radius);
      font-size: var(--el-messagebox-font-size);
      box-shadow: var(--el-messagebox-box-shadow);
      text-align: left;
      overflow: hidden;
      -webkit-backface-visibility: hidden;
      backface-visibility: hidden;
      box-sizing: border-box;
      overflow-wrap: break-word
    }

    .el-message-box:focus {
      outline: 0 !important
    }

    .el-overlay.is-message-box .el-overlay-message-box {
      text-align: center;
      position: fixed;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      padding: 16px;
      overflow: auto
    }

    .el-overlay.is-message-box .el-overlay-message-box::after {
      content: """";
      display: inline-block;
      height: 100%;
      width: 0;
      vertical-align: middle
    }

    .el-message-box.is-draggable .el-message-box__header {
      cursor: move;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-message-box__header {
      padding-bottom: var(--el-messagebox-padding-primary)
    }

    .el-message-box__header.show-close {
      padding-right: calc(var(--el-messagebox-padding-primary) + var(--el-message-close-size, 16px))
    }

    .el-message-box__title {
      font-size: var(--el-messagebox-font-size);
      line-height: var(--el-messagebox-font-line-height);
      color: var(--el-messagebox-title-color)
    }

    .el-message-box__headerbtn {
      position: absolute;
      top: 0;
      right: 0;
      padding: 0;
      width: 40px;
      height: 40px;
      border: none;
      outline: 0;
      background: 0 0;
      font-size: var(--el-message-close-size, 16px);
      cursor: pointer
    }

    .el-message-box__headerbtn .el-message-box__close {
      color: var(--el-color-info);
      font-size: inherit
    }

    .el-message-box__headerbtn:focus .el-message-box__close,
    .el-message-box__headerbtn:hover .el-message-box__close {
      color: var(--el-color-primary)
    }

    .el-message-box__content {
      color: var(--el-messagebox-content-color);
      font-size: var(--el-messagebox-content-font-size)
    }

    .el-message-box__container {
      display: flex;
      align-items: center;
      gap: 12px
    }

    .el-message-box__input {
      padding-top: 12px
    }

    .el-message-box__input div.invalid>input {
      border-color: var(--el-color-error)
    }

    .el-message-box__input div.invalid>input:focus {
      border-color: var(--el-color-error)
    }

    .el-message-box__status {
      font-size: 24px
    }

    .el-message-box__status.el-message-box-icon--success {
      --el-messagebox-color: var(--el-color-success);
      color: var(--el-messagebox-color)
    }

    .el-message-box__status.el-message-box-icon--info {
      --el-messagebox-color: var(--el-color-info);
      color: var(--el-messagebox-color)
    }

    .el-message-box__status.el-message-box-icon--warning {
      --el-messagebox-color: var(--el-color-warning);
      color: var(--el-messagebox-color)
    }

    .el-message-box__status.el-message-box-icon--error {
      --el-messagebox-color: var(--el-color-error);
      color: var(--el-messagebox-color)
    }

    .el-message-box__message {
      margin: 0
    }

    .el-message-box__message p {
      margin: 0;
      line-height: var(--el-messagebox-font-line-height)
    }

    .el-message-box__errormsg {
      color: var(--el-color-error);
      font-size: var(--el-messagebox-error-font-size);
      line-height: var(--el-messagebox-font-line-height)
    }

    .el-message-box__btns {
      display: flex;
      flex-wrap: wrap;
      justify-content: flex-end;
      align-items: center;
      padding-top: var(--el-messagebox-padding-primary)
    }

    .el-message-box--center .el-message-box__title {
      display: flex;
      align-items: center;
      justify-content: center;
      gap: 6px
    }

    .el-message-box--center .el-message-box__status {
      font-size: inherit
    }

    .el-message-box--center .el-message-box__btns {
      justify-content: center
    }

    .el-message-box--center .el-message-box__container {
      justify-content: center
    }

    .fade-in-linear-enter-active .el-overlay-message-box {
      -webkit-animation: msgbox-fade-in var(--el-transition-duration);
      animation: msgbox-fade-in var(--el-transition-duration)
    }

    .fade-in-linear-leave-active .el-overlay-message-box {
      animation: msgbox-fade-in var(--el-transition-duration) reverse
    }

    @-webkit-keyframes msgbox-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    @keyframes msgbox-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    .el-message {
      --el-message-bg-color: var(--el-color-info-light-9);
      --el-message-border-color: var(--el-border-color-lighter);
      --el-message-padding: 15px 19px;
      --el-message-close-size: 16px;
      --el-message-close-icon-color: var(--el-text-color-placeholder);
      --el-message-close-hover-color: var(--el-text-color-secondary)
    }

    .el-message {
      width: -webkit-fit-content;
      width: -moz-fit-content;
      width: fit-content;
      max-width: calc(100% - 32px);
      box-sizing: border-box;
      border-radius: var(--el-border-radius-base);
      border-width: var(--el-border-width);
      border-style: var(--el-border-style);
      border-color: var(--el-message-border-color);
      position: fixed;
      left: 50%;
      top: 20px;
      transform: translateX(-50%);
      background-color: var(--el-message-bg-color);
      transition: opacity var(--el-transition-duration), transform .4s, top .4s;
      padding: var(--el-message-padding);
      display: flex;
      align-items: center
    }

    .el-message.is-center {
      justify-content: center
    }

    .el-message.is-closable .el-message__content {
      padding-right: 31px
    }

    .el-message p {
      margin: 0
    }

    .el-message--success {
      --el-message-bg-color: var(--el-color-success-light-9);
      --el-message-border-color: var(--el-color-success-light-8);
      --el-message-text-color: var(--el-color-success)
    }

    .el-message--success .el-message__content {
      color: var(--el-message-text-color);
      overflow-wrap: break-word
    }

    .el-message .el-message-icon--success {
      color: var(--el-message-text-color)
    }

    .el-message--info {
      --el-message-bg-color: var(--el-color-info-light-9);
      --el-message-border-color: var(--el-color-info-light-8);
      --el-message-text-color: var(--el-color-info)
    }

    .el-message--info .el-message__content {
      color: var(--el-message-text-color);
      overflow-wrap: break-word
    }

    .el-message .el-message-icon--info {
      color: var(--el-message-text-color)
    }

    .el-message--warning {
      --el-message-bg-color: var(--el-color-warning-light-9);
      --el-message-border-color: var(--el-color-warning-light-8);
      --el-message-text-color: var(--el-color-warning)
    }

    .el-message--warning .el-message__content {
      color: var(--el-message-text-color);
      overflow-wrap: break-word
    }

    .el-message .el-message-icon--warning {
      color: var(--el-message-text-color)
    }

    .el-message--error {
      --el-message-bg-color: var(--el-color-error-light-9);
      --el-message-border-color: var(--el-color-error-light-8);
      --el-message-text-color: var(--el-color-error)
    }

    .el-message--error .el-message__content {
      color: var(--el-message-text-color);
      overflow-wrap: break-word
    }

    .el-message .el-message-icon--error {
      color: var(--el-message-text-color)
    }

    .el-message__icon {
      margin-right: 10px
    }

    .el-message .el-message__badge {
      position: absolute;
      top: -8px;
      right: -8px
    }

    .el-message__content {
      padding: 0;
      font-size: 14px;
      line-height: 1
    }

    .el-message__content:focus {
      outline-width: 0
    }

    .el-message .el-message__closeBtn {
      position: absolute;
      top: 50%;
      right: 19px;
      transform: translateY(-50%);
      cursor: pointer;
      color: var(--el-message-close-icon-color);
      font-size: var(--el-message-close-size)
    }

    .el-message .el-message__closeBtn:focus {
      outline-width: 0
    }

    .el-message .el-message__closeBtn:hover {
      color: var(--el-message-close-hover-color)
    }

    .el-message-fade-enter-from,
    .el-message-fade-leave-to {
      opacity: 0;
      transform: translate(-50%, -100%)
    }

    .el-notification {
      --el-notification-width: 330px;
      --el-notification-padding: 14px 26px 14px 13px;
      --el-notification-radius: 8px;
      --el-notification-shadow: var(--el-box-shadow-light);
      --el-notification-border-color: var(--el-border-color-lighter);
      --el-notification-icon-size: 24px;
      --el-notification-close-font-size: var(--el-message-close-size, 16px);
      --el-notification-group-margin-left: 13px;
      --el-notification-group-margin-right: 8px;
      --el-notification-content-font-size: var(--el-font-size-base);
      --el-notification-content-color: var(--el-text-color-regular);
      --el-notification-title-font-size: 16px;
      --el-notification-title-color: var(--el-text-color-primary);
      --el-notification-close-color: var(--el-text-color-secondary);
      --el-notification-close-hover-color: var(--el-text-color-regular)
    }

    .el-notification {
      display: flex;
      width: var(--el-notification-width);
      padding: var(--el-notification-padding);
      border-radius: var(--el-notification-radius);
      box-sizing: border-box;
      border: 1px solid var(--el-notification-border-color);
      position: fixed;
      background-color: var(--el-bg-color-overlay);
      box-shadow: var(--el-notification-shadow);
      transition: opacity var(--el-transition-duration), transform var(--el-transition-duration), left var(--el-transition-duration), right var(--el-transition-duration), top .4s, bottom var(--el-transition-duration);
      overflow-wrap: break-word;
      overflow: hidden;
      z-index: 9999
    }

    .el-notification.right {
      right: 16px
    }

    .el-notification.left {
      left: 16px
    }

    .el-notification__group {
      margin-left: var(--el-notification-group-margin-left);
      margin-right: var(--el-notification-group-margin-right)
    }

    .el-notification__title {
      font-weight: 700;
      font-size: var(--el-notification-title-font-size);
      line-height: var(--el-notification-icon-size);
      color: var(--el-notification-title-color);
      margin: 0
    }

    .el-notification__content {
      font-size: var(--el-notification-content-font-size);
      line-height: 24px;
      margin: 6px 0 0;
      color: var(--el-notification-content-color)
    }

    .el-notification__content p {
      margin: 0
    }

    .el-notification .el-notification__icon {
      height: var(--el-notification-icon-size);
      width: var(--el-notification-icon-size);
      font-size: var(--el-notification-icon-size)
    }

    .el-notification .el-notification__closeBtn {
      position: absolute;
      top: 18px;
      right: 15px;
      cursor: pointer;
      color: var(--el-notification-close-color);
      font-size: var(--el-notification-close-font-size)
    }

    .el-notification .el-notification__closeBtn:hover {
      color: var(--el-notification-close-hover-color)
    }

    .el-notification .el-notification--success {
      --el-notification-icon-color: var(--el-color-success);
      color: var(--el-notification-icon-color)
    }

    .el-notification .el-notification--info {
      --el-notification-icon-color: var(--el-color-info);
      color: var(--el-notification-icon-color)
    }

    .el-notification .el-notification--warning {
      --el-notification-icon-color: var(--el-color-warning);
      color: var(--el-notification-icon-color)
    }

    .el-notification .el-notification--error {
      --el-notification-icon-color: var(--el-color-error);
      color: var(--el-notification-icon-color)
    }

    .el-notification-fade-enter-from.right {
      right: 0;
      transform: translateX(100%)
    }

    .el-notification-fade-enter-from.left {
      left: 0;
      transform: translateX(-100%)
    }

    .el-notification-fade-leave-to {
      opacity: 0
    }

    .el-overlay {
      position: fixed;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      z-index: 2000;
      height: 100%;
      background-color: var(--el-overlay-color-lighter);
      overflow: auto
    }

    .el-overlay .el-overlay-root {
      height: 0
    }

    .el-page-header.is-contentful .el-page-header__main {
      border-top: 1px solid var(--el-border-color-light);
      margin-top: 16px
    }

    .el-page-header__header {
      display: flex;
      align-items: center;
      justify-content: space-between;
      line-height: 24px
    }

    .el-page-header__left {
      display: flex;
      align-items: center;
      margin-right: 40px;
      position: relative
    }

    .el-page-header__back {
      display: flex;
      align-items: center;
      cursor: pointer
    }

    .el-page-header__left .el-divider--vertical {
      margin: 0 16px
    }

    .el-page-header__icon {
      font-size: 16px;
      margin-right: 10px;
      display: flex;
      align-items: center
    }

    .el-page-header__icon .el-icon {
      font-size: inherit
    }

    .el-page-header__title {
      font-size: 14px;
      font-weight: 500
    }

    .el-page-header__content {
      font-size: 18px;
      color: var(--el-text-color-primary)
    }

    .el-page-header__breadcrumb {
      margin-bottom: 16px
    }

    .el-pagination {
      --el-pagination-font-size: 14px;
      --el-pagination-bg-color: var(--el-fill-color-blank);
      --el-pagination-text-color: var(--el-text-color-primary);
      --el-pagination-border-radius: 2px;
      --el-pagination-button-color: var(--el-text-color-primary);
      --el-pagination-button-width: 32px;
      --el-pagination-button-height: 32px;
      --el-pagination-button-disabled-color: var(--el-text-color-placeholder);
      --el-pagination-button-disabled-bg-color: var(--el-fill-color-blank);
      --el-pagination-button-bg-color: var(--el-fill-color);
      --el-pagination-hover-color: var(--el-color-primary);
      --el-pagination-font-size-small: 12px;
      --el-pagination-button-width-small: 24px;
      --el-pagination-button-height-small: 24px;
      --el-pagination-item-gap: 16px;
      white-space: nowrap;
      color: var(--el-pagination-text-color);
      font-size: var(--el-pagination-font-size);
      font-weight: 400;
      display: flex;
      align-items: center
    }

    .el-pagination .el-input__inner {
      text-align: center;
      -moz-appearance: textfield
    }

    .el-pagination .el-select {
      width: 128px
    }

    .el-pagination button {
      display: flex;
      justify-content: center;
      align-items: center;
      font-size: var(--el-pagination-font-size);
      min-width: var(--el-pagination-button-width);
      height: var(--el-pagination-button-height);
      line-height: var(--el-pagination-button-height);
      color: var(--el-pagination-button-color);
      background: var(--el-pagination-bg-color);
      padding: 0 4px;
      border: none;
      border-radius: var(--el-pagination-border-radius);
      cursor: pointer;
      text-align: center;
      box-sizing: border-box
    }

    .el-pagination button * {
      pointer-events: none
    }

    .el-pagination button:focus {
      outline: 0
    }

    .el-pagination button:hover {
      color: var(--el-pagination-hover-color)
    }

    .el-pagination button.is-active {
      color: var(--el-pagination-hover-color);
      cursor: default;
      font-weight: 700
    }

    .el-pagination button.is-active.is-disabled {
      font-weight: 700;
      color: var(--el-text-color-secondary)
    }

    .el-pagination button.is-disabled,
    .el-pagination button:disabled {
      color: var(--el-pagination-button-disabled-color);
      background-color: var(--el-pagination-button-disabled-bg-color);
      cursor: not-allowed
    }

    .el-pagination button:focus-visible {
      outline: 1px solid var(--el-pagination-hover-color);
      outline-offset: -1px
    }

    .el-pagination .btn-next .el-icon,
    .el-pagination .btn-prev .el-icon {
      display: block;
      font-size: 12px;
      font-weight: 700;
      width: inherit
    }

    .el-pagination>.is-first {
      margin-left: 0 !important
    }

    .el-pagination>.is-last {
      margin-right: 0 !important
    }

    .el-pagination .btn-prev {
      margin-left: var(--el-pagination-item-gap)
    }

    .el-pagination__sizes {
      margin-left: var(--el-pagination-item-gap);
      font-weight: 400;
      color: var(--el-text-color-regular)
    }

    .el-pagination__total {
      margin-left: var(--el-pagination-item-gap);
      font-weight: 400;
      color: var(--el-text-color-regular)
    }

    .el-pagination__total[disabled=true] {
      color: var(--el-text-color-placeholder)
    }

    .el-pagination__jump {
      display: flex;
      align-items: center;
      margin-left: var(--el-pagination-item-gap);
      font-weight: 400;
      color: var(--el-text-color-regular)
    }

    .el-pagination__jump[disabled=true] {
      color: var(--el-text-color-placeholder)
    }

    .el-pagination__goto {
      margin-right: 8px
    }

    .el-pagination__editor {
      text-align: center;
      box-sizing: border-box
    }

    .el-pagination__editor.el-input {
      width: 56px
    }

    .el-pagination__editor .el-input__inner::-webkit-inner-spin-button,
    .el-pagination__editor .el-input__inner::-webkit-outer-spin-button {
      -webkit-appearance: none;
      margin: 0
    }

    .el-pagination__classifier {
      margin-left: 8px
    }

    .el-pagination__rightwrapper {
      flex: 1;
      display: flex;
      align-items: center;
      justify-content: flex-end
    }

    .el-pagination.is-background .btn-next,
    .el-pagination.is-background .btn-prev,
    .el-pagination.is-background .el-pager li {
      margin: 0 4px;
      background-color: var(--el-pagination-button-bg-color)
    }

    .el-pagination.is-background .btn-next.is-active,
    .el-pagination.is-background .btn-prev.is-active,
    .el-pagination.is-background .el-pager li.is-active {
      background-color: var(--el-color-primary);
      color: var(--el-color-white)
    }

    .el-pagination.is-background .btn-next.is-disabled,
    .el-pagination.is-background .btn-next:disabled,
    .el-pagination.is-background .btn-prev.is-disabled,
    .el-pagination.is-background .btn-prev:disabled,
    .el-pagination.is-background .el-pager li.is-disabled,
    .el-pagination.is-background .el-pager li:disabled {
      color: var(--el-text-color-placeholder);
      background-color: var(--el-disabled-bg-color)
    }

    .el-pagination.is-background .btn-next.is-disabled.is-active,
    .el-pagination.is-background .btn-next:disabled.is-active,
    .el-pagination.is-background .btn-prev.is-disabled.is-active,
    .el-pagination.is-background .btn-prev:disabled.is-active,
    .el-pagination.is-background .el-pager li.is-disabled.is-active,
    .el-pagination.is-background .el-pager li:disabled.is-active {
      color: var(--el-text-color-secondary);
      background-color: var(--el-fill-color-dark)
    }

    .el-pagination.is-background .btn-prev {
      margin-left: var(--el-pagination-item-gap)
    }

    .el-pagination--small .btn-next,
    .el-pagination--small .btn-prev,
    .el-pagination--small .el-pager li {
      height: var(--el-pagination-button-height-small);
      line-height: var(--el-pagination-button-height-small);
      font-size: var(--el-pagination-font-size-small);
      min-width: var(--el-pagination-button-width-small)
    }

    .el-pagination--small button,
    .el-pagination--small span:not([class*=suffix]) {
      font-size: var(--el-pagination-font-size-small)
    }

    .el-pagination--small .el-select {
      width: 100px
    }

    .el-pager {
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      list-style: none;
      font-size: 0;
      padding: 0;
      margin: 0;
      display: flex;
      align-items: center
    }

    .el-pager li {
      display: flex;
      justify-content: center;
      align-items: center;
      font-size: var(--el-pagination-font-size);
      min-width: var(--el-pagination-button-width);
      height: var(--el-pagination-button-height);
      line-height: var(--el-pagination-button-height);
      color: var(--el-pagination-button-color);
      background: var(--el-pagination-bg-color);
      padding: 0 4px;
      border: none;
      border-radius: var(--el-pagination-border-radius);
      cursor: pointer;
      text-align: center;
      box-sizing: border-box
    }

    .el-pager li * {
      pointer-events: none
    }

    .el-pager li:focus {
      outline: 0
    }

    .el-pager li:hover {
      color: var(--el-pagination-hover-color)
    }

    .el-pager li.is-active {
      color: var(--el-pagination-hover-color);
      cursor: default;
      font-weight: 700
    }

    .el-pager li.is-active.is-disabled {
      font-weight: 700;
      color: var(--el-text-color-secondary)
    }

    .el-pager li.is-disabled,
    .el-pager li:disabled {
      color: var(--el-pagination-button-disabled-color);
      background-color: var(--el-pagination-button-disabled-bg-color);
      cursor: not-allowed
    }

    .el-pager li:focus-visible {
      outline: 1px solid var(--el-pagination-hover-color);
      outline-offset: -1px
    }

    .el-popconfirm__main {
      display: flex;
      align-items: center
    }

    .el-popconfirm__icon {
      margin-right: 5px
    }

    .el-popconfirm__action {
      text-align: right;
      margin-top: 8px
    }

    .el-popover {
      --el-popover-bg-color: var(--el-bg-color-overlay);
      --el-popover-font-size: var(--el-font-size-base);
      --el-popover-border-color: var(--el-border-color-lighter);
      --el-popover-padding: 12px;
      --el-popover-padding-large: 18px 20px;
      --el-popover-title-font-size: 16px;
      --el-popover-title-text-color: var(--el-text-color-primary);
      --el-popover-border-radius: 4px
    }

    .el-popover.el-popper {
      background: var(--el-popover-bg-color);
      min-width: 150px;
      border-radius: var(--el-popover-border-radius);
      border: 1px solid var(--el-popover-border-color);
      padding: var(--el-popover-padding);
      z-index: var(--el-index-popper);
      color: var(--el-text-color-regular);
      line-height: 1.4;
      font-size: var(--el-popover-font-size);
      box-shadow: var(--el-box-shadow-light);
      overflow-wrap: break-word;
      box-sizing: border-box
    }

    .el-popover.el-popper--plain {
      padding: var(--el-popover-padding-large)
    }

    .el-popover__title {
      color: var(--el-popover-title-text-color);
      font-size: var(--el-popover-title-font-size);
      line-height: 1;
      margin-bottom: 12px
    }

    .el-popover__reference:focus:hover,
    .el-popover__reference:focus:not(.focusing) {
      outline-width: 0
    }

    .el-popover.el-popper.is-dark {
      --el-popover-bg-color: var(--el-text-color-primary);
      --el-popover-border-color: var(--el-text-color-primary);
      --el-popover-title-text-color: var(--el-bg-color);
      color: var(--el-bg-color)
    }

    .el-popover.el-popper:focus,
    .el-popover.el-popper:focus:active {
      outline-width: 0
    }

    .el-progress {
      position: relative;
      line-height: 1;
      display: flex;
      align-items: center
    }

    .el-progress__text {
      font-size: 14px;
      color: var(--el-text-color-regular);
      margin-left: 5px;
      min-width: 50px;
      line-height: 1
    }

    .el-progress__text i {
      vertical-align: middle;
      display: block
    }

    .el-progress--circle,
    .el-progress--dashboard {
      display: inline-block
    }

    .el-progress--circle .el-progress__text,
    .el-progress--dashboard .el-progress__text {
      position: absolute;
      top: 50%;
      left: 0;
      width: 100%;
      text-align: center;
      margin: 0;
      transform: translate(0, -50%)
    }

    .el-progress--circle .el-progress__text i,
    .el-progress--dashboard .el-progress__text i {
      vertical-align: middle;
      display: inline-block
    }

    .el-progress--without-text .el-progress__text {
      display: none
    }

    .el-progress--without-text .el-progress-bar {
      padding-right: 0;
      margin-right: 0;
      display: block
    }

    .el-progress--text-inside .el-progress-bar {
      padding-right: 0;
      margin-right: 0
    }

    .el-progress.is-success .el-progress-bar__inner {
      background-color: var(--el-color-success)
    }

    .el-progress.is-success .el-progress__text {
      color: var(--el-color-success)
    }

    .el-progress.is-warning .el-progress-bar__inner {
      background-color: var(--el-color-warning)
    }

    .el-progress.is-warning .el-progress__text {
      color: var(--el-color-warning)
    }

    .el-progress.is-exception .el-progress-bar__inner {
      background-color: var(--el-color-danger)
    }

    .el-progress.is-exception .el-progress__text {
      color: var(--el-color-danger)
    }

    .el-progress-bar {
      flex-grow: 1;
      box-sizing: border-box
    }

    .el-progress-bar__outer {
      height: 6px;
      border-radius: 100px;
      background-color: var(--el-border-color-lighter);
      overflow: hidden;
      position: relative;
      vertical-align: middle
    }

    .el-progress-bar__inner {
      position: absolute;
      left: 0;
      top: 0;
      height: 100%;
      background-color: var(--el-color-primary);
      text-align: right;
      border-radius: 100px;
      line-height: 1;
      white-space: nowrap;
      transition: width .6s ease
    }

    .el-progress-bar__inner::after {
      display: inline-block;
      content: """";
      height: 100%;
      vertical-align: middle
    }

    .el-progress-bar__inner--indeterminate {
      transform: translateZ(0);
      -webkit-animation: indeterminate 3s infinite;
      animation: indeterminate 3s infinite
    }

    .el-progress-bar__inner--striped {
      background-image: linear-gradient(45deg, rgba(0, 0, 0, .1) 25%, transparent 25%, transparent 50%, rgba(0, 0, 0, .1) 50%, rgba(0, 0, 0, .1) 75%, transparent 75%, transparent);
      background-size: 1.25em 1.25em
    }

    .el-progress-bar__inner--striped.el-progress-bar__inner--striped-flow {
      -webkit-animation: striped-flow 3s linear infinite;
      animation: striped-flow 3s linear infinite
    }

    .el-progress-bar__innerText {
      display: inline-block;
      vertical-align: middle;
      color: #fff;
      font-size: 12px;
      margin: 0 5px
    }

    @-webkit-keyframes progress {
      0% {
        background-position: 0 0
      }

      100% {
        background-position: 32px 0
      }
    }

    @keyframes progress {
      0% {
        background-position: 0 0
      }

      100% {
        background-position: 32px 0
      }
    }

    @-webkit-keyframes indeterminate {
      0% {
        left: -100%
      }

      100% {
        left: 100%
      }
    }

    @keyframes indeterminate {
      0% {
        left: -100%
      }

      100% {
        left: 100%
      }
    }

    @-webkit-keyframes striped-flow {
      0% {
        background-position: -100%
      }

      100% {
        background-position: 100%
      }
    }

    @keyframes striped-flow {
      0% {
        background-position: -100%
      }

      100% {
        background-position: 100%
      }
    }

    .el-radio-button {
      --el-radio-button-checked-bg-color: var(--el-color-primary);
      --el-radio-button-checked-text-color: var(--el-color-white);
      --el-radio-button-checked-border-color: var(--el-color-primary);
      --el-radio-button-disabled-checked-fill: var(--el-border-color-extra-light)
    }

    .el-radio-button {
      position: relative;
      display: inline-block;
      outline: 0
    }

    .el-radio-button__inner {
      display: inline-block;
      line-height: 1;
      white-space: nowrap;
      vertical-align: middle;
      background: var(--el-button-bg-color, var(--el-fill-color-blank));
      border: var(--el-border);
      font-weight: var(--el-button-font-weight, var(--el-font-weight-primary));
      border-left: 0;
      color: var(--el-button-text-color, var(--el-text-color-regular));
      -webkit-appearance: none;
      text-align: center;
      box-sizing: border-box;
      outline: 0;
      margin: 0;
      position: relative;
      cursor: pointer;
      transition: var(--el-transition-all);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      padding: 8px 15px;
      font-size: var(--el-font-size-base);
      border-radius: 0
    }

    .el-radio-button__inner.is-round {
      padding: 8px 15px
    }

    .el-radio-button__inner:hover {
      color: var(--el-color-primary)
    }

    .el-radio-button__inner [class*=el-icon-] {
      line-height: .9
    }

    .el-radio-button__inner [class*=el-icon-]+span {
      margin-left: 5px
    }

    .el-radio-button:first-child .el-radio-button__inner {
      border-left: var(--el-border);
      border-radius: var(--el-border-radius-base) 0 0 var(--el-border-radius-base);
      box-shadow: none !important
    }

    .el-radio-button__original-radio {
      opacity: 0;
      outline: 0;
      position: absolute;
      z-index: -1
    }

    .el-radio-button__original-radio:checked+.el-radio-button__inner {
      color: var(--el-radio-button-checked-text-color, var(--el-color-white));
      background-color: var(--el-radio-button-checked-bg-color, var(--el-color-primary));
      border-color: var(--el-radio-button-checked-border-color, var(--el-color-primary));
      box-shadow: -1px 0 0 0 var(--el-radio-button-checked-border-color, var(--el-color-primary))
    }

    .el-radio-button__original-radio:focus-visible+.el-radio-button__inner {
      border-left: var(--el-border);
      border-left-color: var(--el-radio-button-checked-border-color, var(--el-color-primary));
      outline: 2px solid var(--el-radio-button-checked-border-color);
      outline-offset: 1px;
      z-index: 2;
      border-radius: var(--el-border-radius-base);
      box-shadow: none
    }

    .el-radio-button__original-radio:disabled+.el-radio-button__inner {
      color: var(--el-disabled-text-color);
      cursor: not-allowed;
      background-image: none;
      background-color: var(--el-button-disabled-bg-color, var(--el-fill-color-blank));
      border-color: var(--el-button-disabled-border-color, var(--el-border-color-light));
      box-shadow: none
    }

    .el-radio-button__original-radio:disabled:checked+.el-radio-button__inner {
      background-color: var(--el-radio-button-disabled-checked-fill)
    }

    .el-radio-button:last-child .el-radio-button__inner {
      border-radius: 0 var(--el-border-radius-base) var(--el-border-radius-base) 0
    }

    .el-radio-button:first-child:last-child .el-radio-button__inner {
      border-radius: var(--el-border-radius-base)
    }

    .el-radio-button--large .el-radio-button__inner {
      padding: 12px 19px;
      font-size: var(--el-font-size-base);
      border-radius: 0
    }

    .el-radio-button--large .el-radio-button__inner.is-round {
      padding: 12px 19px
    }

    .el-radio-button--small .el-radio-button__inner {
      padding: 5px 11px;
      font-size: 12px;
      border-radius: 0
    }

    .el-radio-button--small .el-radio-button__inner.is-round {
      padding: 5px 11px
    }

    .el-radio-group {
      display: inline-flex;
      align-items: center;
      flex-wrap: wrap;
      font-size: 0
    }

    .el-radio {
      --el-radio-font-size: var(--el-font-size-base);
      --el-radio-text-color: var(--el-text-color-regular);
      --el-radio-font-weight: var(--el-font-weight-primary);
      --el-radio-input-height: 14px;
      --el-radio-input-width: 14px;
      --el-radio-input-border-radius: var(--el-border-radius-circle);
      --el-radio-input-bg-color: var(--el-fill-color-blank);
      --el-radio-input-border: var(--el-border);
      --el-radio-input-border-color: var(--el-border-color);
      --el-radio-input-border-color-hover: var(--el-color-primary)
    }

    .el-radio {
      color: var(--el-radio-text-color);
      font-weight: var(--el-radio-font-weight);
      position: relative;
      cursor: pointer;
      display: inline-flex;
      align-items: center;
      white-space: nowrap;
      outline: 0;
      font-size: var(--el-font-size-base);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      margin-right: 32px;
      height: 32px
    }

    .el-radio.el-radio--large {
      height: 40px
    }

    .el-radio.el-radio--small {
      height: 24px
    }

    .el-radio.is-bordered {
      padding: 0 15px 0 9px;
      border-radius: var(--el-border-radius-base);
      border: var(--el-border);
      box-sizing: border-box
    }

    .el-radio.is-bordered.is-checked {
      border-color: var(--el-color-primary)
    }

    .el-radio.is-bordered.is-disabled {
      cursor: not-allowed;
      border-color: var(--el-border-color-lighter)
    }

    .el-radio.is-bordered.el-radio--large {
      padding: 0 19px 0 11px;
      border-radius: var(--el-border-radius-base)
    }

    .el-radio.is-bordered.el-radio--large .el-radio__label {
      font-size: var(--el-font-size-base)
    }

    .el-radio.is-bordered.el-radio--large .el-radio__inner {
      height: 14px;
      width: 14px
    }

    .el-radio.is-bordered.el-radio--small {
      padding: 0 11px 0 7px;
      border-radius: var(--el-border-radius-base)
    }

    .el-radio.is-bordered.el-radio--small .el-radio__label {
      font-size: 12px
    }

    .el-radio.is-bordered.el-radio--small .el-radio__inner {
      height: 12px;
      width: 12px
    }

    .el-radio:last-child {
      margin-right: 0
    }

    .el-radio__input {
      white-space: nowrap;
      cursor: pointer;
      outline: 0;
      display: inline-flex;
      position: relative;
      vertical-align: middle
    }

    .el-radio__input.is-disabled .el-radio__inner {
      background-color: var(--el-disabled-bg-color);
      border-color: var(--el-disabled-border-color);
      cursor: not-allowed
    }

    .el-radio__input.is-disabled .el-radio__inner::after {
      cursor: not-allowed;
      background-color: var(--el-disabled-bg-color)
    }

    .el-radio__input.is-disabled .el-radio__inner+.el-radio__label {
      cursor: not-allowed
    }

    .el-radio__input.is-disabled.is-checked .el-radio__inner {
      background-color: var(--el-disabled-bg-color);
      border-color: var(--el-disabled-border-color)
    }

    .el-radio__input.is-disabled.is-checked .el-radio__inner::after {
      background-color: var(--el-text-color-placeholder)
    }

    .el-radio__input.is-disabled+span.el-radio__label {
      color: var(--el-text-color-placeholder);
      cursor: not-allowed
    }

    .el-radio__input.is-checked .el-radio__inner {
      border-color: var(--el-color-primary);
      background: var(--el-color-primary)
    }

    .el-radio__input.is-checked .el-radio__inner::after {
      transform: translate(-50%, -50%) scale(1)
    }

    .el-radio__input.is-checked+.el-radio__label {
      color: var(--el-color-primary)
    }

    .el-radio__input.is-focus .el-radio__inner {
      border-color: var(--el-radio-input-border-color-hover)
    }

    .el-radio__inner {
      border: var(--el-radio-input-border);
      border-radius: var(--el-radio-input-border-radius);
      width: var(--el-radio-input-width);
      height: var(--el-radio-input-height);
      background-color: var(--el-radio-input-bg-color);
      position: relative;
      cursor: pointer;
      display: inline-block;
      box-sizing: border-box
    }

    .el-radio__inner:hover {
      border-color: var(--el-radio-input-border-color-hover)
    }

    .el-radio__inner::after {
      width: 4px;
      height: 4px;
      border-radius: var(--el-radio-input-border-radius);
      background-color: var(--el-color-white);
      content: """";
      position: absolute;
      left: 50%;
      top: 50%;
      transform: translate(-50%, -50%) scale(0);
      transition: transform .15s ease-in
    }

    .el-radio__original {
      opacity: 0;
      outline: 0;
      position: absolute;
      z-index: -1;
      top: 0;
      left: 0;
      right: 0;
      bottom: 0;
      margin: 0
    }

    .el-radio__original:focus-visible+.el-radio__inner {
      outline: 2px solid var(--el-radio-input-border-color-hover);
      outline-offset: 1px;
      border-radius: var(--el-radio-input-border-radius)
    }

    .el-radio:focus:not(:focus-visible):not(.is-focus):not(:active):not(.is-disabled) .el-radio__inner {
      box-shadow: 0 0 2px 2px var(--el-radio-input-border-color-hover)
    }

    .el-radio__label {
      font-size: var(--el-radio-font-size);
      padding-left: 8px
    }

    .el-radio.el-radio--large .el-radio__label {
      font-size: 14px
    }

    .el-radio.el-radio--large .el-radio__inner {
      width: 14px;
      height: 14px
    }

    .el-radio.el-radio--small .el-radio__label {
      font-size: 12px
    }

    .el-radio.el-radio--small .el-radio__inner {
      width: 12px;
      height: 12px
    }

    .el-rate {
      --el-rate-height: 20px;
      --el-rate-font-size: var(--el-font-size-base);
      --el-rate-icon-size: 18px;
      --el-rate-icon-margin: 6px;
      --el-rate-void-color: var(--el-border-color-darker);
      --el-rate-fill-color: #f7ba2a;
      --el-rate-disabled-void-color: var(--el-fill-color);
      --el-rate-text-color: var(--el-text-color-primary)
    }

    .el-rate {
      display: inline-flex;
      align-items: center;
      height: 32px
    }

    .el-rate:active,
    .el-rate:focus {
      outline: 0
    }

    .el-rate__item {
      cursor: pointer;
      display: inline-block;
      position: relative;
      font-size: 0;
      vertical-align: middle;
      color: var(--el-rate-void-color);
      line-height: normal
    }

    .el-rate .el-rate__icon {
      position: relative;
      display: inline-block;
      font-size: var(--el-rate-icon-size);
      margin-right: var(--el-rate-icon-margin);
      transition: var(--el-transition-duration)
    }

    .el-rate .el-rate__icon.hover {
      transform: scale(1.15)
    }

    .el-rate .el-rate__icon .path2 {
      position: absolute;
      left: 0;
      top: 0
    }

    .el-rate .el-rate__icon.is-active {
      color: var(--el-rate-fill-color)
    }

    .el-rate__decimal {
      position: absolute;
      top: 0;
      left: 0;
      display: inline-block;
      overflow: hidden;
      color: var(--el-rate-fill-color)
    }

    .el-rate__decimal--box {
      position: absolute;
      top: 0;
      left: 0
    }

    .el-rate__text {
      font-size: var(--el-rate-font-size);
      vertical-align: middle;
      color: var(--el-rate-text-color)
    }

    .el-rate--large {
      height: 40px
    }

    .el-rate--small {
      height: 24px
    }

    .el-rate--small .el-rate__icon {
      font-size: 14px
    }

    .el-rate.is-disabled .el-rate__item {
      cursor: auto;
      color: var(--el-rate-disabled-void-color)
    }

    .el-result {
      --el-result-padding: 40px 30px;
      --el-result-icon-font-size: 64px;
      --el-result-title-font-size: 20px;
      --el-result-title-margin-top: 20px;
      --el-result-subtitle-margin-top: 10px;
      --el-result-extra-margin-top: 30px
    }

    .el-result {
      display: flex;
      justify-content: center;
      align-items: center;
      flex-direction: column;
      text-align: center;
      box-sizing: border-box;
      padding: var(--el-result-padding)
    }

    .el-result__icon svg {
      width: var(--el-result-icon-font-size);
      height: var(--el-result-icon-font-size)
    }

    .el-result__title {
      margin-top: var(--el-result-title-margin-top)
    }

    .el-result__title p {
      margin: 0;
      font-size: var(--el-result-title-font-size);
      color: var(--el-text-color-primary);
      line-height: 1.3
    }

    .el-result__subtitle {
      margin-top: var(--el-result-subtitle-margin-top)
    }

    .el-result__subtitle p {
      margin: 0;
      font-size: var(--el-font-size-base);
      color: var(--el-text-color-regular);
      line-height: 1.3
    }

    .el-result__extra {
      margin-top: var(--el-result-extra-margin-top)
    }

    .el-result .icon-primary {
      --el-result-color: var(--el-color-primary);
      color: var(--el-result-color)
    }

    .el-result .icon-success {
      --el-result-color: var(--el-color-success);
      color: var(--el-result-color)
    }

    .el-result .icon-warning {
      --el-result-color: var(--el-color-warning);
      color: var(--el-result-color)
    }

    .el-result .icon-danger {
      --el-result-color: var(--el-color-danger);
      color: var(--el-result-color)
    }

    .el-result .icon-error {
      --el-result-color: var(--el-color-error);
      color: var(--el-result-color)
    }

    .el-result .icon-info {
      --el-result-color: var(--el-color-info);
      color: var(--el-result-color)
    }

    .el-row {
      display: flex;
      flex-wrap: wrap;
      position: relative;
      box-sizing: border-box
    }

    .el-row.is-justify-center {
      justify-content: center
    }

    .el-row.is-justify-end {
      justify-content: flex-end
    }

    .el-row.is-justify-space-between {
      justify-content: space-between
    }

    .el-row.is-justify-space-around {
      justify-content: space-around
    }

    .el-row.is-justify-space-evenly {
      justify-content: space-evenly
    }

    .el-row.is-align-top {
      align-items: flex-start
    }

    .el-row.is-align-middle {
      align-items: center
    }

    .el-row.is-align-bottom {
      align-items: flex-end
    }

    .el-scrollbar {
      --el-scrollbar-opacity: 0.3;
      --el-scrollbar-bg-color: var(--el-text-color-secondary);
      --el-scrollbar-hover-opacity: 0.5;
      --el-scrollbar-hover-bg-color: var(--el-text-color-secondary)
    }

    .el-scrollbar {
      overflow: hidden;
      position: relative;
      height: 100%
    }

    .el-scrollbar__wrap {
      overflow: auto;
      height: 100%
    }

    .el-scrollbar__wrap--hidden-default {
      scrollbar-width: none
    }

    .el-scrollbar__wrap--hidden-default::-webkit-scrollbar {
      display: none
    }

    .el-scrollbar__thumb {
      position: relative;
      display: block;
      width: 0;
      height: 0;
      cursor: pointer;
      border-radius: inherit;
      background-color: var(--el-scrollbar-bg-color, var(--el-text-color-secondary));
      transition: var(--el-transition-duration) background-color;
      opacity: var(--el-scrollbar-opacity, .3)
    }

    .el-scrollbar__thumb:hover {
      background-color: var(--el-scrollbar-hover-bg-color, var(--el-text-color-secondary));
      opacity: var(--el-scrollbar-hover-opacity, .5)
    }

    .el-scrollbar__bar {
      position: absolute;
      right: 2px;
      bottom: 2px;
      z-index: 1;
      border-radius: 4px
    }

    .el-scrollbar__bar.is-vertical {
      width: 6px;
      top: 2px
    }

    .el-scrollbar__bar.is-vertical>div {
      width: 100%
    }

    .el-scrollbar__bar.is-horizontal {
      height: 6px;
      left: 2px
    }

    .el-scrollbar__bar.is-horizontal>div {
      height: 100%
    }

    .el-scrollbar-fade-enter-active {
      transition: opacity 340ms ease-out
    }

    .el-scrollbar-fade-leave-active {
      transition: opacity 120ms ease-out
    }

    .el-scrollbar-fade-enter-from,
    .el-scrollbar-fade-leave-active {
      opacity: 0
    }

    .el-select-dropdown {
      z-index: calc(var(--el-index-top) + 1);
      border-radius: var(--el-border-radius-base);
      box-sizing: border-box
    }

    .el-select-dropdown .el-scrollbar.is-empty .el-select-dropdown__list {
      padding: 0
    }

    .el-select-dropdown__loading {
      padding: 10px 0;
      margin: 0;
      text-align: center;
      color: var(--el-text-color-secondary);
      font-size: var(--el-select-font-size)
    }

    .el-select-dropdown__empty {
      padding: 10px 0;
      margin: 0;
      text-align: center;
      color: var(--el-text-color-secondary);
      font-size: var(--el-select-font-size)
    }

    .el-select-dropdown__wrap {
      max-height: 274px
    }

    .el-select-dropdown__list {
      list-style: none;
      padding: 6px 0;
      margin: 0;
      box-sizing: border-box
    }

    .el-select-dropdown__list.el-vl__window {
      margin: 6px 0;
      padding: 0
    }

    .el-select-dropdown__header {
      padding: 10px;
      border-bottom: 1px solid var(--el-border-color-light)
    }

    .el-select-dropdown__footer {
      padding: 10px;
      border-top: 1px solid var(--el-border-color-light)
    }

    .el-select-dropdown__item {
      font-size: var(--el-font-size-base);
      padding: 0 32px 0 20px;
      position: relative;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;
      color: var(--el-text-color-regular);
      height: 34px;
      line-height: 34px;
      box-sizing: border-box;
      cursor: pointer
    }

    .el-select-dropdown__item.is-hovering {
      background-color: var(--el-fill-color-light)
    }

    .el-select-dropdown__item.is-selected {
      color: var(--el-color-primary);
      font-weight: 700
    }

    .el-select-dropdown__item.is-disabled {
      color: var(--el-text-color-placeholder);
      cursor: not-allowed;
      background-color: unset
    }

    .el-select-dropdown.is-multiple .el-select-dropdown__item.is-selected::after {
      content: """";
      position: absolute;
      top: 50%;
      right: 20px;
      border-top: none;
      border-right: none;
      background-repeat: no-repeat;
      background-position: center;
      background-color: var(--el-color-primary);
      -webkit-mask: url(""data:image/svg+xml;utf8,%3Csvg class='icon' width='200' height='200' viewBox='0 0 1024 1024' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath fill='currentColor' d='M406.656 706.944L195.84 496.256a32 32 0 10-45.248 45.248l256 256 512-512a32 32 0 00-45.248-45.248L406.592 706.944z'%3E%3C/path%3E%3C/svg%3E"") no-repeat;
      mask: url(""data:image/svg+xml;utf8,%3Csvg class='icon' width='200' height='200' viewBox='0 0 1024 1024' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath fill='currentColor' d='M406.656 706.944L195.84 496.256a32 32 0 10-45.248 45.248l256 256 512-512a32 32 0 00-45.248-45.248L406.592 706.944z'%3E%3C/path%3E%3C/svg%3E"") no-repeat;
      mask-size: 100% 100%;
      -webkit-mask: url(""data:image/svg+xml;utf8,%3Csvg class='icon' width='200' height='200' viewBox='0 0 1024 1024' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath fill='currentColor' d='M406.656 706.944L195.84 496.256a32 32 0 10-45.248 45.248l256 256 512-512a32 32 0 00-45.248-45.248L406.592 706.944z'%3E%3C/path%3E%3C/svg%3E"") no-repeat;
      -webkit-mask-size: 100% 100%;
      transform: translateY(-50%);
      width: 12px;
      height: 12px
    }

    .el-select-dropdown.is-multiple .el-select-dropdown__item.is-disabled::after {
      background-color: var(--el-text-color-placeholder)
    }

    .el-select-group {
      margin: 0;
      padding: 0
    }

    .el-select-group__wrap {
      position: relative;
      list-style: none;
      margin: 0;
      padding: 0
    }

    .el-select-group__wrap:not(:last-of-type) {
      padding-bottom: 24px
    }

    .el-select-group__wrap:not(:last-of-type)::after {
      content: """";
      position: absolute;
      display: block;
      left: 20px;
      right: 20px;
      bottom: 12px;
      height: 1px;
      background: var(--el-border-color-light)
    }

    .el-select-group__split-dash {
      position: absolute;
      left: 20px;
      right: 20px;
      height: 1px;
      background: var(--el-border-color-light)
    }

    .el-select-group__title {
      padding-left: 20px;
      font-size: 12px;
      color: var(--el-color-info);
      line-height: 30px
    }

    .el-select-group .el-select-dropdown__item {
      padding-left: 20px
    }

    .el-select {
      --el-select-border-color-hover: var(--el-border-color-hover);
      --el-select-disabled-border: var(--el-disabled-border-color);
      --el-select-font-size: var(--el-font-size-base);
      --el-select-close-hover-color: var(--el-text-color-secondary);
      --el-select-input-color: var(--el-text-color-placeholder);
      --el-select-multiple-input-color: var(--el-text-color-regular);
      --el-select-input-focus-border-color: var(--el-color-primary);
      --el-select-input-font-size: 14px;
      --el-select-width: 100%
    }

    .el-select {
      display: inline-block;
      position: relative;
      vertical-align: middle;
      width: var(--el-select-width)
    }

    .el-select__wrapper {
      display: flex;
      align-items: center;
      position: relative;
      box-sizing: border-box;
      cursor: pointer;
      text-align: left;
      font-size: 14px;
      padding: 4px 12px;
      gap: 6px;
      min-height: 32px;
      line-height: 24px;
      border-radius: var(--el-border-radius-base);
      background-color: var(--el-fill-color-blank);
      transition: var(--el-transition-duration);
      box-shadow: 0 0 0 1px var(--el-border-color) inset
    }

    .el-select__wrapper:hover {
      box-shadow: 0 0 0 1px var(--el-text-color) inset
    }

    .el-select__wrapper.is-filterable {
      cursor: text
    }

    .el-select__wrapper.is-focused {
      box-shadow: 0 0 0 1px var(--el-color-primary) inset
    }

    .el-select__wrapper.is-hovering:not(.is-focused) {
      box-shadow: 0 0 0 1px var(--el-border-color-hover) inset
    }

    .el-select__wrapper.is-disabled {
      cursor: not-allowed;
      background-color: var(--el-fill-color-light);
      color: var(--el-text-color-placeholder);
      box-shadow: 0 0 0 1px var(--el-select-disabled-border) inset
    }

    .el-select__wrapper.is-disabled:hover {
      box-shadow: 0 0 0 1px var(--el-select-disabled-border) inset
    }

    .el-select__wrapper.is-disabled.is-focus {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-select__wrapper.is-disabled .el-select__caret {
      cursor: not-allowed
    }

    .el-select__wrapper.is-disabled .el-tag {
      cursor: not-allowed
    }

    .el-select__prefix {
      display: flex;
      align-items: center;
      flex-shrink: 0;
      gap: 6px;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder))
    }

    .el-select__suffix {
      display: flex;
      align-items: center;
      flex-shrink: 0;
      gap: 6px;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder))
    }

    .el-select__caret {
      color: var(--el-select-input-color);
      font-size: var(--el-select-input-font-size);
      transition: var(--el-transition-duration);
      transform: rotateZ(0);
      cursor: pointer
    }

    .el-select__caret.is-reverse {
      transform: rotateZ(180deg)
    }

    .el-select__selection {
      position: relative;
      display: flex;
      flex-wrap: wrap;
      align-items: center;
      flex: 1;
      min-width: 0;
      gap: 6px
    }

    .el-select__selection.is-near {
      margin-left: -8px
    }

    .el-select__selection .el-tag {
      cursor: pointer;
      border-color: transparent
    }

    .el-select__selection .el-tag .el-tag__content {
      min-width: 0
    }

    .el-select__selected-item {
      display: flex;
      flex-wrap: wrap;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-select__tags-text {
      display: block;
      line-height: normal;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap
    }

    .el-select__placeholder {
      position: absolute;
      display: block;
      top: 50%;
      transform: translateY(-50%);
      width: 100%;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap;
      color: var(--el-input-text-color, var(--el-text-color-regular))
    }

    .el-select__placeholder.is-transparent {
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      color: var(--el-text-color-placeholder)
    }

    .el-select__popper.el-popper {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-border-color-light);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-select__popper.el-popper .el-popper__arrow::before {
      border: 1px solid var(--el-border-color-light)
    }

    .el-select__popper.el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-select__popper.el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-select__popper.el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-select__popper.el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-select__input-wrapper {
      max-width: 100%
    }

    .el-select__input-wrapper.is-hidden {
      position: absolute;
      opacity: 0
    }

    .el-select__input {
      border: none;
      outline: 0;
      padding: 0;
      color: var(--el-select-multiple-input-color);
      font-size: inherit;
      font-family: inherit;
      -webkit-appearance: none;
      -moz-appearance: none;
      appearance: none;
      height: 24px;
      max-width: 100%;
      background-color: transparent
    }

    .el-select__input.is-disabled {
      cursor: not-allowed
    }

    .el-select__input-calculator {
      position: absolute;
      left: 0;
      top: 0;
      max-width: 100%;
      visibility: hidden;
      white-space: pre;
      overflow: hidden
    }

    .el-select--large .el-select__wrapper {
      gap: 6px;
      padding: 8px 16px;
      min-height: 40px;
      line-height: 24px;
      font-size: 14px
    }

    .el-select--large .el-select__selection {
      gap: 6px
    }

    .el-select--large .el-select__selection.is-near {
      margin-left: -8px
    }

    .el-select--large .el-select__prefix {
      gap: 6px
    }

    .el-select--large .el-select__suffix {
      gap: 6px
    }

    .el-select--large .el-select__input {
      height: 24px
    }

    .el-select--small .el-select__wrapper {
      gap: 4px;
      padding: 2px 8px;
      min-height: 24px;
      line-height: 20px;
      font-size: 12px
    }

    .el-select--small .el-select__selection {
      gap: 4px
    }

    .el-select--small .el-select__selection.is-near {
      margin-left: -6px
    }

    .el-select--small .el-select__prefix {
      gap: 4px
    }

    .el-select--small .el-select__suffix {
      gap: 4px
    }

    .el-select--small .el-select__input {
      height: 20px
    }

    .el-skeleton {
      --el-skeleton-circle-size: var(--el-avatar-size)
    }

    .el-skeleton__item {
      background: var(--el-skeleton-color);
      display: inline-block;
      height: 16px;
      border-radius: var(--el-border-radius-base);
      width: 100%
    }

    .el-skeleton__circle {
      border-radius: 50%;
      width: var(--el-skeleton-circle-size);
      height: var(--el-skeleton-circle-size);
      line-height: var(--el-skeleton-circle-size)
    }

    .el-skeleton__button {
      height: 40px;
      width: 64px;
      border-radius: 4px
    }

    .el-skeleton__p {
      width: 100%
    }

    .el-skeleton__p.is-last {
      width: 61%
    }

    .el-skeleton__p.is-first {
      width: 33%
    }

    .el-skeleton__text {
      width: 100%;
      height: var(--el-font-size-small)
    }

    .el-skeleton__caption {
      height: var(--el-font-size-extra-small)
    }

    .el-skeleton__h1 {
      height: var(--el-font-size-extra-large)
    }

    .el-skeleton__h3 {
      height: var(--el-font-size-large)
    }

    .el-skeleton__h5 {
      height: var(--el-font-size-medium)
    }

    .el-skeleton__image {
      width: unset;
      display: flex;
      align-items: center;
      justify-content: center;
      border-radius: 0
    }

    .el-skeleton__image svg {
      color: var(--el-svg-monochrome-grey);
      fill: currentColor;
      width: 22%;
      height: 22%
    }

    .el-skeleton {
      --el-skeleton-color: var(--el-fill-color);
      --el-skeleton-to-color: var(--el-fill-color-darker)
    }

    @-webkit-keyframes el-skeleton-loading {
      0% {
        background-position: 100% 50%
      }

      100% {
        background-position: 0 50%
      }
    }

    @keyframes el-skeleton-loading {
      0% {
        background-position: 100% 50%
      }

      100% {
        background-position: 0 50%
      }
    }

    .el-skeleton {
      width: 100%
    }

    .el-skeleton__first-line {
      height: 16px;
      margin-top: 16px;
      background: var(--el-skeleton-color)
    }

    .el-skeleton__paragraph {
      height: 16px;
      margin-top: 16px;
      background: var(--el-skeleton-color)
    }

    .el-skeleton.is-animated .el-skeleton__item {
      background: linear-gradient(90deg, var(--el-skeleton-color) 25%, var(--el-skeleton-to-color) 37%, var(--el-skeleton-color) 63%);
      background-size: 400% 100%;
      -webkit-animation: el-skeleton-loading 1.4s ease infinite;
      animation: el-skeleton-loading 1.4s ease infinite
    }

    .el-slider {
      --el-slider-main-bg-color: var(--el-color-primary);
      --el-slider-runway-bg-color: var(--el-border-color-light);
      --el-slider-stop-bg-color: var(--el-color-white);
      --el-slider-disabled-color: var(--el-text-color-placeholder);
      --el-slider-border-radius: 3px;
      --el-slider-height: 6px;
      --el-slider-button-size: 20px;
      --el-slider-button-wrapper-size: 36px;
      --el-slider-button-wrapper-offset: -15px
    }

    .el-slider {
      width: 100%;
      height: 32px;
      display: flex;
      align-items: center
    }

    .el-slider__runway {
      flex: 1;
      height: var(--el-slider-height);
      background-color: var(--el-slider-runway-bg-color);
      border-radius: var(--el-slider-border-radius);
      position: relative;
      cursor: pointer
    }

    .el-slider__runway.show-input {
      margin-right: 30px;
      width: auto
    }

    .el-slider__runway.is-disabled {
      cursor: default
    }

    .el-slider__runway.is-disabled .el-slider__bar {
      background-color: var(--el-slider-disabled-color)
    }

    .el-slider__runway.is-disabled .el-slider__button {
      border-color: var(--el-slider-disabled-color)
    }

    .el-slider__runway.is-disabled .el-slider__button-wrapper.hover,
    .el-slider__runway.is-disabled .el-slider__button-wrapper:hover {
      cursor: not-allowed
    }

    .el-slider__runway.is-disabled .el-slider__button-wrapper.dragging {
      cursor: not-allowed
    }

    .el-slider__runway.is-disabled .el-slider__button.dragging,
    .el-slider__runway.is-disabled .el-slider__button.hover,
    .el-slider__runway.is-disabled .el-slider__button:hover {
      transform: scale(1)
    }

    .el-slider__runway.is-disabled .el-slider__button.hover,
    .el-slider__runway.is-disabled .el-slider__button:hover {
      cursor: not-allowed
    }

    .el-slider__runway.is-disabled .el-slider__button.dragging {
      cursor: not-allowed
    }

    .el-slider__input {
      flex-shrink: 0;
      width: 130px
    }

    .el-slider__bar {
      height: var(--el-slider-height);
      background-color: var(--el-slider-main-bg-color);
      border-top-left-radius: var(--el-slider-border-radius);
      border-bottom-left-radius: var(--el-slider-border-radius);
      position: absolute
    }

    .el-slider__button-wrapper {
      height: var(--el-slider-button-wrapper-size);
      width: var(--el-slider-button-wrapper-size);
      position: absolute;
      z-index: 1;
      top: var(--el-slider-button-wrapper-offset);
      transform: translateX(-50%);
      background-color: transparent;
      text-align: center;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      line-height: normal;
      outline: 0
    }

    .el-slider__button-wrapper::after {
      display: inline-block;
      content: """";
      height: 100%;
      vertical-align: middle
    }

    .el-slider__button-wrapper.hover,
    .el-slider__button-wrapper:hover {
      cursor: -webkit-grab;
      cursor: grab
    }

    .el-slider__button-wrapper.dragging {
      cursor: -webkit-grabbing;
      cursor: grabbing
    }

    .el-slider__button {
      display: inline-block;
      width: var(--el-slider-button-size);
      height: var(--el-slider-button-size);
      vertical-align: middle;
      border: solid 2px var(--el-slider-main-bg-color);
      background-color: var(--el-color-white);
      border-radius: 50%;
      box-sizing: border-box;
      transition: var(--el-transition-duration-fast);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-slider__button.dragging,
    .el-slider__button.hover,
    .el-slider__button:hover {
      transform: scale(1.2)
    }

    .el-slider__button.hover,
    .el-slider__button:hover {
      cursor: -webkit-grab;
      cursor: grab
    }

    .el-slider__button.dragging {
      cursor: -webkit-grabbing;
      cursor: grabbing
    }

    .el-slider__stop {
      position: absolute;
      height: var(--el-slider-height);
      width: var(--el-slider-height);
      border-radius: var(--el-border-radius-circle);
      background-color: var(--el-slider-stop-bg-color);
      transform: translateX(-50%)
    }

    .el-slider__marks {
      top: 0;
      left: 12px;
      width: 18px;
      height: 100%
    }

    .el-slider__marks-text {
      position: absolute;
      transform: translateX(-50%);
      font-size: 14px;
      color: var(--el-color-info);
      margin-top: 15px;
      white-space: pre
    }

    .el-slider.is-vertical {
      position: relative;
      display: inline-flex;
      width: auto;
      height: 100%;
      flex: 0
    }

    .el-slider.is-vertical .el-slider__runway {
      width: var(--el-slider-height);
      height: 100%;
      margin: 0 16px
    }

    .el-slider.is-vertical .el-slider__bar {
      width: var(--el-slider-height);
      height: auto;
      border-radius: 0 0 3px 3px
    }

    .el-slider.is-vertical .el-slider__button-wrapper {
      top: auto;
      left: var(--el-slider-button-wrapper-offset);
      transform: translateY(50%)
    }

    .el-slider.is-vertical .el-slider__stop {
      transform: translateY(50%)
    }

    .el-slider.is-vertical .el-slider__marks-text {
      margin-top: 0;
      left: 15px;
      transform: translateY(50%)
    }

    .el-slider--large {
      height: 40px
    }

    .el-slider--small {
      height: 24px
    }

    .el-space {
      display: inline-flex;
      vertical-align: top
    }

    .el-space__item {
      display: flex;
      flex-wrap: wrap
    }

    .el-space__item>* {
      flex: 1
    }

    .el-space--vertical {
      flex-direction: column
    }

    .el-time-spinner {
      width: 100%;
      white-space: nowrap
    }

    .el-spinner {
      display: inline-block;
      vertical-align: middle
    }

    .el-spinner-inner {
      -webkit-animation: rotate 2s linear infinite;
      animation: rotate 2s linear infinite;
      width: 50px;
      height: 50px
    }

    .el-spinner-inner .path {
      stroke: var(--el-border-color-lighter);
      stroke-linecap: round;
      -webkit-animation: dash 1.5s ease-in-out infinite;
      animation: dash 1.5s ease-in-out infinite
    }

    @-webkit-keyframes rotate {
      100% {
        transform: rotate(360deg)
      }
    }

    @keyframes rotate {
      100% {
        transform: rotate(360deg)
      }
    }

    @-webkit-keyframes dash {
      0% {
        stroke-dasharray: 1, 150;
        stroke-dashoffset: 0
      }

      50% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -35
      }

      100% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -124
      }
    }

    @keyframes dash {
      0% {
        stroke-dasharray: 1, 150;
        stroke-dashoffset: 0
      }

      50% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -35
      }

      100% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -124
      }
    }

    .el-step {
      position: relative;
      flex-shrink: 1
    }

    .el-step:last-of-type .el-step__line {
      display: none
    }

    .el-step:last-of-type.is-flex {
      flex-basis: auto !important;
      flex-shrink: 0;
      flex-grow: 0
    }

    .el-step:last-of-type .el-step__description,
    .el-step:last-of-type .el-step__main {
      padding-right: 0
    }

    .el-step__head {
      position: relative;
      width: 100%
    }

    .el-step__head.is-process {
      color: var(--el-text-color-primary);
      border-color: var(--el-text-color-primary)
    }

    .el-step__head.is-wait {
      color: var(--el-text-color-placeholder);
      border-color: var(--el-text-color-placeholder)
    }

    .el-step__head.is-success {
      color: var(--el-color-success);
      border-color: var(--el-color-success)
    }

    .el-step__head.is-error {
      color: var(--el-color-danger);
      border-color: var(--el-color-danger)
    }

    .el-step__head.is-finish {
      color: var(--el-color-primary);
      border-color: var(--el-color-primary)
    }

    .el-step__icon {
      position: relative;
      z-index: 1;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      width: 24px;
      height: 24px;
      font-size: 14px;
      box-sizing: border-box;
      background: var(--el-bg-color);
      transition: .15s ease-out
    }

    .el-step__icon.is-text {
      border-radius: 50%;
      border: 2px solid;
      border-color: inherit
    }

    .el-step__icon.is-icon {
      width: 40px
    }

    .el-step__icon-inner {
      display: inline-block;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      text-align: center;
      font-weight: 700;
      line-height: 1;
      color: inherit
    }

    .el-step__icon-inner[class*=el-icon]:not(.is-status) {
      font-size: 25px;
      font-weight: 400
    }

    .el-step__icon-inner.is-status {
      transform: translateY(1px)
    }

    .el-step__line {
      position: absolute;
      border-color: inherit;
      background-color: var(--el-text-color-placeholder)
    }

    .el-step__line-inner {
      display: block;
      border-width: 1px;
      border-style: solid;
      border-color: inherit;
      transition: .15s ease-out;
      box-sizing: border-box;
      width: 0;
      height: 0
    }

    .el-step__main {
      white-space: normal;
      text-align: left
    }

    .el-step__title {
      font-size: 16px;
      line-height: 38px
    }

    .el-step__title.is-process {
      font-weight: 700;
      color: var(--el-text-color-primary)
    }

    .el-step__title.is-wait {
      color: var(--el-text-color-placeholder)
    }

    .el-step__title.is-success {
      color: var(--el-color-success)
    }

    .el-step__title.is-error {
      color: var(--el-color-danger)
    }

    .el-step__title.is-finish {
      color: var(--el-color-primary)
    }

    .el-step__description {
      padding-right: 10%;
      margin-top: -5px;
      font-size: 12px;
      line-height: 20px;
      font-weight: 400
    }

    .el-step__description.is-process {
      color: var(--el-text-color-primary)
    }

    .el-step__description.is-wait {
      color: var(--el-text-color-placeholder)
    }

    .el-step__description.is-success {
      color: var(--el-color-success)
    }

    .el-step__description.is-error {
      color: var(--el-color-danger)
    }

    .el-step__description.is-finish {
      color: var(--el-color-primary)
    }

    .el-step.is-horizontal {
      display: inline-block
    }

    .el-step.is-horizontal .el-step__line {
      height: 2px;
      top: 11px;
      left: 0;
      right: 0
    }

    .el-step.is-vertical {
      display: flex
    }

    .el-step.is-vertical .el-step__head {
      flex-grow: 0;
      width: 24px
    }

    .el-step.is-vertical .el-step__main {
      padding-left: 10px;
      flex-grow: 1
    }

    .el-step.is-vertical .el-step__title {
      line-height: 24px;
      padding-bottom: 8px
    }

    .el-step.is-vertical .el-step__line {
      width: 2px;
      top: 0;
      bottom: 0;
      left: 11px
    }

    .el-step.is-vertical .el-step__icon.is-icon {
      width: 24px
    }

    .el-step.is-center .el-step__head {
      text-align: center
    }

    .el-step.is-center .el-step__main {
      text-align: center
    }

    .el-step.is-center .el-step__description {
      padding-left: 20%;
      padding-right: 20%
    }

    .el-step.is-center .el-step__line {
      left: 50%;
      right: -50%
    }

    .el-step.is-simple {
      display: flex;
      align-items: center
    }

    .el-step.is-simple .el-step__head {
      width: auto;
      font-size: 0;
      padding-right: 10px
    }

    .el-step.is-simple .el-step__icon {
      background: 0 0;
      width: 16px;
      height: 16px;
      font-size: 12px
    }

    .el-step.is-simple .el-step__icon-inner[class*=el-icon]:not(.is-status) {
      font-size: 18px
    }

    .el-step.is-simple .el-step__icon-inner.is-status {
      transform: scale(.8) translateY(1px)
    }

    .el-step.is-simple .el-step__main {
      position: relative;
      display: flex;
      align-items: stretch;
      flex-grow: 1
    }

    .el-step.is-simple .el-step__title {
      font-size: 16px;
      line-height: 20px
    }

    .el-step.is-simple:not(:last-of-type) .el-step__title {
      max-width: 50%;
      overflow-wrap: break-word
    }

    .el-step.is-simple .el-step__arrow {
      flex-grow: 1;
      display: flex;
      align-items: center;
      justify-content: center
    }

    .el-step.is-simple .el-step__arrow::after,
    .el-step.is-simple .el-step__arrow::before {
      content: """";
      display: inline-block;
      position: absolute;
      height: 15px;
      width: 1px;
      background: var(--el-text-color-placeholder)
    }

    .el-step.is-simple .el-step__arrow::before {
      transform: rotate(-45deg) translateY(-4px);
      transform-origin: 0 0
    }

    .el-step.is-simple .el-step__arrow::after {
      transform: rotate(45deg) translateY(4px);
      transform-origin: 100% 100%
    }

    .el-step.is-simple:last-of-type .el-step__arrow {
      display: none
    }

    .el-steps {
      display: flex
    }

    .el-steps--simple {
      padding: 13px 8%;
      border-radius: 4px;
      background: var(--el-fill-color-light)
    }

    .el-steps--horizontal {
      white-space: nowrap
    }

    .el-steps--vertical {
      height: 100%;
      flex-flow: column
    }

    .el-switch {
      --el-switch-on-color: var(--el-color-primary);
      --el-switch-off-color: var(--el-border-color)
    }

    .el-switch {
      display: inline-flex;
      align-items: center;
      position: relative;
      font-size: 14px;
      line-height: 20px;
      height: 32px;
      vertical-align: middle
    }

    .el-switch.is-disabled .el-switch__core,
    .el-switch.is-disabled .el-switch__label {
      cursor: not-allowed
    }

    .el-switch__label {
      transition: var(--el-transition-duration-fast);
      height: 20px;
      display: inline-block;
      font-size: 14px;
      font-weight: 500;
      cursor: pointer;
      vertical-align: middle;
      color: var(--el-text-color-primary)
    }

    .el-switch__label.is-active {
      color: var(--el-color-primary)
    }

    .el-switch__label--left {
      margin-right: 10px
    }

    .el-switch__label--right {
      margin-left: 10px
    }

    .el-switch__label * {
      line-height: 1;
      font-size: 14px;
      display: inline-block
    }

    .el-switch__label .el-icon {
      height: inherit
    }

    .el-switch__label .el-icon svg {
      vertical-align: middle
    }

    .el-switch__input {
      position: absolute;
      width: 0;
      height: 0;
      opacity: 0;
      margin: 0
    }

    .el-switch__input:focus-visible~.el-switch__core {
      outline: 2px solid var(--el-switch-on-color);
      outline-offset: 1px
    }

    .el-switch__core {
      display: inline-flex;
      position: relative;
      align-items: center;
      min-width: 40px;
      height: 20px;
      border: 1px solid var(--el-switch-border-color, var(--el-switch-off-color));
      outline: 0;
      border-radius: 10px;
      box-sizing: border-box;
      background: var(--el-switch-off-color);
      cursor: pointer;
      transition: border-color var(--el-transition-duration), background-color var(--el-transition-duration)
    }

    .el-switch__core .el-switch__inner {
      width: 100%;
      transition: all var(--el-transition-duration);
      height: 16px;
      display: flex;
      justify-content: center;
      align-items: center;
      overflow: hidden;
      padding: 0 4px 0 calc(16px + 2px)
    }

    .el-switch__core .el-switch__inner .is-icon,
    .el-switch__core .el-switch__inner .is-text {
      font-size: 12px;
      color: var(--el-color-white);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap
    }

    .el-switch__core .el-switch__action {
      position: absolute;
      left: 1px;
      border-radius: var(--el-border-radius-circle);
      transition: all var(--el-transition-duration);
      width: 16px;
      height: 16px;
      background-color: var(--el-color-white);
      display: flex;
      justify-content: center;
      align-items: center;
      color: var(--el-switch-off-color)
    }

    .el-switch.is-checked .el-switch__core {
      border-color: var(--el-switch-border-color, var(--el-switch-on-color));
      background-color: var(--el-switch-on-color)
    }

    .el-switch.is-checked .el-switch__core .el-switch__action {
      left: calc(100% - 17px);
      color: var(--el-switch-on-color)
    }

    .el-switch.is-checked .el-switch__core .el-switch__inner {
      padding: 0 calc(16px + 2px) 0 4px
    }

    .el-switch.is-disabled {
      opacity: .6
    }

    .el-switch--wide .el-switch__label.el-switch__label--left span {
      left: 10px
    }

    .el-switch--wide .el-switch__label.el-switch__label--right span {
      right: 10px
    }

    .el-switch .label-fade-enter-from,
    .el-switch .label-fade-leave-active {
      opacity: 0
    }

    .el-switch--large {
      font-size: 14px;
      line-height: 24px;
      height: 40px
    }

    .el-switch--large .el-switch__label {
      height: 24px;
      font-size: 14px
    }

    .el-switch--large .el-switch__label * {
      font-size: 14px
    }

    .el-switch--large .el-switch__core {
      min-width: 50px;
      height: 24px;
      border-radius: 12px
    }

    .el-switch--large .el-switch__core .el-switch__inner {
      height: 20px;
      padding: 0 6px 0 calc(20px + 2px)
    }

    .el-switch--large .el-switch__core .el-switch__action {
      width: 20px;
      height: 20px
    }

    .el-switch--large.is-checked .el-switch__core .el-switch__action {
      left: calc(100% - 21px)
    }

    .el-switch--large.is-checked .el-switch__core .el-switch__inner {
      padding: 0 calc(20px + 2px) 0 6px
    }

    .el-switch--small {
      font-size: 12px;
      line-height: 16px;
      height: 24px
    }

    .el-switch--small .el-switch__label {
      height: 16px;
      font-size: 12px
    }

    .el-switch--small .el-switch__label * {
      font-size: 12px
    }

    .el-switch--small .el-switch__core {
      min-width: 30px;
      height: 16px;
      border-radius: 8px
    }

    .el-switch--small .el-switch__core .el-switch__inner {
      height: 12px;
      padding: 0 2px 0 calc(12px + 2px)
    }

    .el-switch--small .el-switch__core .el-switch__action {
      width: 12px;
      height: 12px
    }

    .el-switch--small.is-checked .el-switch__core .el-switch__action {
      left: calc(100% - 13px)
    }

    .el-switch--small.is-checked .el-switch__core .el-switch__inner {
      padding: 0 calc(12px + 2px) 0 2px
    }

    .el-table-column--selection .cell {
      padding-left: 14px;
      padding-right: 14px
    }

    .el-table-filter {
      border: solid 1px var(--el-border-color-lighter);
      border-radius: 2px;
      background-color: #fff;
      box-shadow: var(--el-box-shadow-light);
      box-sizing: border-box
    }

    .el-table-filter__list {
      padding: 5px 0;
      margin: 0;
      list-style: none;
      min-width: 100px
    }

    .el-table-filter__list-item {
      line-height: 36px;
      padding: 0 10px;
      cursor: pointer;
      font-size: var(--el-font-size-base)
    }

    .el-table-filter__list-item:hover {
      background-color: var(--el-color-primary-light-9);
      color: var(--el-color-primary)
    }

    .el-table-filter__list-item.is-active {
      background-color: var(--el-color-primary);
      color: #fff
    }

    .el-table-filter__content {
      min-width: 100px
    }

    .el-table-filter__bottom {
      border-top: 1px solid var(--el-border-color-lighter);
      padding: 8px
    }

    .el-table-filter__bottom button {
      background: 0 0;
      border: none;
      color: var(--el-text-color-regular);
      cursor: pointer;
      font-size: var(--el-font-size-small);
      padding: 0 3px
    }

    .el-table-filter__bottom button:hover {
      color: var(--el-color-primary)
    }

    .el-table-filter__bottom button:focus {
      outline: 0
    }

    .el-table-filter__bottom button.is-disabled {
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-table-filter__wrap {
      max-height: 280px
    }

    .el-table-filter__checkbox-group {
      padding: 10px
    }

    .el-table-filter__checkbox-group label.el-checkbox {
      display: flex;
      align-items: center;
      margin-right: 5px;
      margin-bottom: 12px;
      margin-left: 5px;
      height: unset
    }

    .el-table-filter__checkbox-group .el-checkbox:last-child {
      margin-bottom: 0
    }

    .el-table {
      --el-table-border-color: var(--el-border-color-lighter);
      --el-table-border: 1px solid var(--el-table-border-color);
      --el-table-text-color: var(--el-text-color-regular);
      --el-table-header-text-color: var(--el-text-color-secondary);
      --el-table-row-hover-bg-color: var(--el-fill-color-light);
      --el-table-current-row-bg-color: var(--el-color-primary-light-9);
      --el-table-header-bg-color: var(--el-bg-color);
      --el-table-fixed-box-shadow: var(--el-box-shadow-light);
      --el-table-bg-color: var(--el-fill-color-blank);
      --el-table-tr-bg-color: var(--el-bg-color);
      --el-table-expanded-cell-bg-color: var(--el-fill-color-blank);
      --el-table-fixed-left-column: inset 10px 0 10px -10px rgba(0, 0, 0, 0.15);
      --el-table-fixed-right-column: inset -10px 0 10px -10px rgba(0, 0, 0, 0.15);
      --el-table-index: var(--el-index-normal)
    }

    .el-table {
      position: relative;
      overflow: hidden;
      box-sizing: border-box;
      height: -webkit-fit-content;
      height: -moz-fit-content;
      height: fit-content;
      width: 100%;
      max-width: 100%;
      background-color: var(--el-table-bg-color);
      font-size: 14px;
      color: var(--el-table-text-color)
    }

    .el-table__inner-wrapper {
      position: relative;
      display: flex;
      flex-direction: column;
      height: 100%
    }

    .el-table__inner-wrapper::before {
      left: 0;
      bottom: 0;
      width: 100%;
      height: 1px
    }

    .el-table tbody:focus-visible {
      outline: 0
    }

    .el-table.has-footer.el-table--fluid-height tr:last-child td.el-table__cell,
    .el-table.has-footer.el-table--scrollable-y tr:last-child td.el-table__cell {
      border-bottom-color: transparent
    }

    .el-table__empty-block {
      position: -webkit-sticky;
      position: sticky;
      left: 0;
      min-height: 60px;
      text-align: center;
      width: 100%;
      display: flex;
      justify-content: center;
      align-items: center
    }

    .el-table__empty-text {
      line-height: 60px;
      width: 50%;
      color: var(--el-text-color-secondary)
    }

    .el-table__expand-column .cell {
      padding: 0;
      text-align: center;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-table__expand-icon {
      position: relative;
      cursor: pointer;
      color: var(--el-text-color-regular);
      font-size: 12px;
      transition: transform var(--el-transition-duration-fast) ease-in-out;
      height: 20px
    }

    .el-table__expand-icon--expanded {
      transform: rotate(90deg)
    }

    .el-table__expand-icon>.el-icon {
      font-size: 12px
    }

    .el-table__expanded-cell {
      background-color: var(--el-table-expanded-cell-bg-color)
    }

    .el-table__expanded-cell[class*=cell] {
      padding: 20px 50px
    }

    .el-table__expanded-cell:hover {
      background-color: transparent !important
    }

    .el-table__placeholder {
      display: inline-block;
      width: 20px
    }

    .el-table__append-wrapper {
      overflow: hidden
    }

    .el-table--fit {
      border-right: 0;
      border-bottom: 0
    }

    .el-table--fit .el-table__cell.gutter {
      border-right-width: 1px
    }

    .el-table thead {
      color: var(--el-table-header-text-color)
    }

    .el-table thead th {
      font-weight: 600
    }

    .el-table thead.is-group th.el-table__cell {
      background: var(--el-fill-color-light)
    }

    .el-table .el-table__cell {
      padding: 8px 0;
      min-width: 0;
      box-sizing: border-box;
      text-overflow: ellipsis;
      vertical-align: middle;
      position: relative;
      text-align: left;
      z-index: var(--el-table-index)
    }

    .el-table .el-table__cell.is-center {
      text-align: center
    }

    .el-table .el-table__cell.is-right {
      text-align: right
    }

    .el-table .el-table__cell.gutter {
      width: 15px;
      border-right-width: 0;
      border-bottom-width: 0;
      padding: 0
    }

    .el-table .el-table__cell.is-hidden>* {
      visibility: hidden
    }

    .el-table .cell {
      box-sizing: border-box;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: normal;
      overflow-wrap: break-word;
      line-height: 23px;
      padding: 0 12px
    }

    .el-table .cell.el-tooltip {
      white-space: nowrap;
      min-width: 50px
    }

    .el-table--large {
      font-size: var(--el-font-size-base)
    }

    .el-table--large .el-table__cell {
      padding: 12px 0
    }

    .el-table--large .cell {
      padding: 0 16px
    }

    .el-table--default {
      font-size: 14px
    }

    .el-table--default .el-table__cell {
      padding: 8px 0
    }

    .el-table--default .cell {
      padding: 0 12px
    }

    .el-table--small {
      font-size: 12px
    }

    .el-table--small .el-table__cell {
      padding: 4px 0
    }

    .el-table--small .cell {
      padding: 0 8px
    }

    .el-table tr {
      background-color: var(--el-table-tr-bg-color)
    }

    .el-table tr input[type=checkbox] {
      margin: 0
    }

    .el-table td.el-table__cell,
    .el-table th.el-table__cell.is-leaf {
      border-bottom: var(--el-table-border)
    }

    .el-table th.el-table__cell.is-sortable {
      cursor: pointer
    }

    .el-table th.el-table__cell {
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      background-color: var(--el-table-header-bg-color)
    }

    .el-table th.el-table__cell>.cell.highlight {
      color: var(--el-color-primary)
    }

    .el-table th.el-table__cell.required>div::before {
      display: inline-block;
      content: """";
      width: 8px;
      height: 8px;
      border-radius: 50%;
      background: #ff4d51;
      margin-right: 5px;
      vertical-align: middle
    }

    .el-table td.el-table__cell div {
      box-sizing: border-box
    }

    .el-table td.el-table__cell.gutter {
      width: 0
    }

    .el-table--border .el-table__inner-wrapper::after,
    .el-table--border::after,
    .el-table--border::before,
    .el-table__inner-wrapper::before {
      content: """";
      position: absolute;
      background-color: var(--el-table-border-color);
      z-index: calc(var(--el-table-index) + 2)
    }

    .el-table--border .el-table__inner-wrapper::after {
      left: 0;
      top: 0;
      width: 100%;
      height: 1px;
      z-index: calc(var(--el-table-index) + 2)
    }

    .el-table--border::before {
      top: -1px;
      left: 0;
      width: 1px;
      height: 100%
    }

    .el-table--border::after {
      top: -1px;
      right: 0;
      width: 1px;
      height: 100%
    }

    .el-table--border .el-table__inner-wrapper {
      border-right: none;
      border-bottom: none
    }

    .el-table--border .el-table__footer-wrapper {
      position: relative;
      flex-shrink: 0
    }

    .el-table--border .el-table__cell {
      border-right: var(--el-table-border)
    }

    .el-table--border th.el-table__cell.gutter:last-of-type {
      border-bottom: var(--el-table-border);
      border-bottom-width: 1px
    }

    .el-table--border th.el-table__cell {
      border-bottom: var(--el-table-border)
    }

    .el-table--hidden {
      visibility: hidden
    }

    .el-table__body-wrapper,
    .el-table__footer-wrapper,
    .el-table__header-wrapper {
      width: 100%
    }

    .el-table__body-wrapper tr td.el-table-fixed-column--left,
    .el-table__body-wrapper tr td.el-table-fixed-column--right,
    .el-table__body-wrapper tr th.el-table-fixed-column--left,
    .el-table__body-wrapper tr th.el-table-fixed-column--right,
    .el-table__footer-wrapper tr td.el-table-fixed-column--left,
    .el-table__footer-wrapper tr td.el-table-fixed-column--right,
    .el-table__footer-wrapper tr th.el-table-fixed-column--left,
    .el-table__footer-wrapper tr th.el-table-fixed-column--right,
    .el-table__header-wrapper tr td.el-table-fixed-column--left,
    .el-table__header-wrapper tr td.el-table-fixed-column--right,
    .el-table__header-wrapper tr th.el-table-fixed-column--left,
    .el-table__header-wrapper tr th.el-table-fixed-column--right {
      position: -webkit-sticky !important;
      position: sticky !important;
      background: inherit;
      z-index: calc(var(--el-table-index) + 1)
    }

    .el-table__body-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__body-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__body-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__body-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--right.is-first-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--right.is-last-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--right.is-first-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--right.is-last-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--right.is-first-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--right.is-last-column::before {
      content: """";
      position: absolute;
      top: 0;
      width: 10px;
      bottom: -1px;
      overflow-x: hidden;
      overflow-y: hidden;
      box-shadow: none;
      touch-action: none;
      pointer-events: none
    }

    .el-table__body-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__body-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--right.is-first-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--right.is-first-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--right.is-first-column::before {
      left: -10px
    }

    .el-table__body-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__body-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--right.is-last-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--right.is-last-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--right.is-last-column::before {
      right: -10px;
      box-shadow: none
    }

    .el-table__body-wrapper tr td.el-table__fixed-right-patch,
    .el-table__body-wrapper tr th.el-table__fixed-right-patch,
    .el-table__footer-wrapper tr td.el-table__fixed-right-patch,
    .el-table__footer-wrapper tr th.el-table__fixed-right-patch,
    .el-table__header-wrapper tr td.el-table__fixed-right-patch,
    .el-table__header-wrapper tr th.el-table__fixed-right-patch {
      position: -webkit-sticky !important;
      position: sticky !important;
      z-index: calc(var(--el-table-index) + 1);
      background: #fff;
      right: 0
    }

    .el-table__header-wrapper {
      flex-shrink: 0
    }

    .el-table__header-wrapper tr th.el-table-fixed-column--left,
    .el-table__header-wrapper tr th.el-table-fixed-column--right {
      background-color: var(--el-table-header-bg-color)
    }

    .el-table__body,
    .el-table__footer,
    .el-table__header {
      table-layout: fixed;
      border-collapse: separate
    }

    .el-table__header-wrapper {
      overflow: hidden
    }

    .el-table__header-wrapper tbody td.el-table__cell {
      background-color: var(--el-table-row-hover-bg-color);
      color: var(--el-table-text-color)
    }

    .el-table__footer-wrapper {
      overflow: hidden;
      flex-shrink: 0
    }

    .el-table__footer-wrapper tfoot td.el-table__cell {
      background-color: var(--el-table-row-hover-bg-color);
      color: var(--el-table-text-color)
    }

    .el-table__body-wrapper .el-table-column--selection>.cell,
    .el-table__header-wrapper .el-table-column--selection>.cell {
      display: inline-flex;
      align-items: center;
      height: 23px
    }

    .el-table__body-wrapper .el-table-column--selection .el-checkbox,
    .el-table__header-wrapper .el-table-column--selection .el-checkbox {
      height: unset
    }

    .el-table.is-scrolling-left .el-table-fixed-column--right.is-first-column::before {
      box-shadow: var(--el-table-fixed-right-column)
    }

    .el-table.is-scrolling-left.el-table--border .el-table-fixed-column--left.is-last-column.el-table__cell {
      border-right: var(--el-table-border)
    }

    .el-table.is-scrolling-left th.el-table-fixed-column--left {
      background-color: var(--el-table-header-bg-color)
    }

    .el-table.is-scrolling-right .el-table-fixed-column--left.is-last-column::before {
      box-shadow: var(--el-table-fixed-left-column)
    }

    .el-table.is-scrolling-right .el-table-fixed-column--left.is-last-column.el-table__cell {
      border-right: none
    }

    .el-table.is-scrolling-right th.el-table-fixed-column--right {
      background-color: var(--el-table-header-bg-color)
    }

    .el-table.is-scrolling-middle .el-table-fixed-column--left.is-last-column.el-table__cell {
      border-right: none
    }

    .el-table.is-scrolling-middle .el-table-fixed-column--right.is-first-column::before {
      box-shadow: var(--el-table-fixed-right-column)
    }

    .el-table.is-scrolling-middle .el-table-fixed-column--left.is-last-column::before {
      box-shadow: var(--el-table-fixed-left-column)
    }

    .el-table.is-scrolling-none .el-table-fixed-column--left.is-first-column::before,
    .el-table.is-scrolling-none .el-table-fixed-column--left.is-last-column::before,
    .el-table.is-scrolling-none .el-table-fixed-column--right.is-first-column::before,
    .el-table.is-scrolling-none .el-table-fixed-column--right.is-last-column::before {
      box-shadow: none
    }

    .el-table.is-scrolling-none th.el-table-fixed-column--left,
    .el-table.is-scrolling-none th.el-table-fixed-column--right {
      background-color: var(--el-table-header-bg-color)
    }

    .el-table__body-wrapper {
      overflow: hidden;
      position: relative;
      flex: 1
    }

    .el-table__body-wrapper .el-scrollbar__bar {
      z-index: calc(var(--el-table-index) + 2)
    }

    .el-table .caret-wrapper {
      display: inline-flex;
      flex-direction: column;
      align-items: center;
      height: 14px;
      width: 24px;
      vertical-align: middle;
      cursor: pointer;
      overflow: initial;
      position: relative
    }

    .el-table .sort-caret {
      width: 0;
      height: 0;
      border: solid 5px transparent;
      position: absolute;
      left: 7px
    }

    .el-table .sort-caret.ascending {
      border-bottom-color: var(--el-text-color-placeholder);
      top: -5px
    }

    .el-table .sort-caret.descending {
      border-top-color: var(--el-text-color-placeholder);
      bottom: -3px
    }

    .el-table .ascending .sort-caret.ascending {
      border-bottom-color: var(--el-color-primary)
    }

    .el-table .descending .sort-caret.descending {
      border-top-color: var(--el-color-primary)
    }

    .el-table .hidden-columns {
      visibility: hidden;
      position: absolute;
      z-index: -1
    }

    .el-table--striped .el-table__body tr.el-table__row--striped td.el-table__cell {
      background: var(--el-fill-color-lighter)
    }

    .el-table--striped .el-table__body tr.el-table__row--striped.current-row td.el-table__cell {
      background-color: var(--el-table-current-row-bg-color)
    }

    .el-table__body tr.hover-row.current-row>td.el-table__cell,
    .el-table__body tr.hover-row.el-table__row--striped.current-row>td.el-table__cell,
    .el-table__body tr.hover-row.el-table__row--striped>td.el-table__cell,
    .el-table__body tr.hover-row>td.el-table__cell {
      background-color: var(--el-table-row-hover-bg-color)
    }

    .el-table__body tr.current-row>td.el-table__cell {
      background-color: var(--el-table-current-row-bg-color)
    }

    .el-table.el-table--scrollable-y .el-table__body-header {
      position: -webkit-sticky;
      position: sticky;
      top: 0;
      z-index: calc(var(--el-table-index) + 2)
    }

    .el-table.el-table--scrollable-y .el-table__body-footer {
      position: -webkit-sticky;
      position: sticky;
      bottom: 0;
      z-index: calc(var(--el-table-index) + 2)
    }

    .el-table__column-resize-proxy {
      position: absolute;
      left: 200px;
      top: 0;
      bottom: 0;
      width: 0;
      border-left: var(--el-table-border);
      z-index: calc(var(--el-table-index) + 9)
    }

    .el-table__column-filter-trigger {
      display: inline-block;
      cursor: pointer
    }

    .el-table__column-filter-trigger i {
      color: var(--el-color-info);
      font-size: 14px;
      vertical-align: middle
    }

    .el-table__border-left-patch {
      top: 0;
      left: 0;
      width: 1px;
      height: 100%;
      z-index: calc(var(--el-table-index) + 2);
      position: absolute;
      background-color: var(--el-table-border-color)
    }

    .el-table__border-bottom-patch {
      left: 0;
      height: 1px;
      z-index: calc(var(--el-table-index) + 2);
      position: absolute;
      background-color: var(--el-table-border-color)
    }

    .el-table__border-right-patch {
      top: 0;
      height: 100%;
      width: 1px;
      z-index: calc(var(--el-table-index) + 2);
      position: absolute;
      background-color: var(--el-table-border-color)
    }

    .el-table--enable-row-transition .el-table__body td.el-table__cell {
      transition: background-color .25s ease
    }

    .el-table--enable-row-hover .el-table__body tr:hover>td.el-table__cell {
      background-color: var(--el-table-row-hover-bg-color)
    }

    .el-table [class*=el-table__row--level] .el-table__expand-icon {
      display: inline-block;
      width: 12px;
      line-height: 12px;
      height: 12px;
      text-align: center;
      margin-right: 8px
    }

    .el-table .el-table.el-table--border .el-table__cell {
      border-right: var(--el-table-border)
    }

    .el-table:not(.el-table--border) .el-table__cell {
      border-right: none
    }

    .el-table:not(.el-table--border)>.el-table__inner-wrapper::after {
      content: none
    }

    .el-table-v2 {
      --el-table-border-color: var(--el-border-color-lighter);
      --el-table-border: 1px solid var(--el-table-border-color);
      --el-table-text-color: var(--el-text-color-regular);
      --el-table-header-text-color: var(--el-text-color-secondary);
      --el-table-row-hover-bg-color: var(--el-fill-color-light);
      --el-table-current-row-bg-color: var(--el-color-primary-light-9);
      --el-table-header-bg-color: var(--el-bg-color);
      --el-table-fixed-box-shadow: var(--el-box-shadow-light);
      --el-table-bg-color: var(--el-fill-color-blank);
      --el-table-tr-bg-color: var(--el-bg-color);
      --el-table-expanded-cell-bg-color: var(--el-fill-color-blank);
      --el-table-fixed-left-column: inset 10px 0 10px -10px rgba(0, 0, 0, 0.15);
      --el-table-fixed-right-column: inset -10px 0 10px -10px rgba(0, 0, 0, 0.15);
      --el-table-index: var(--el-index-normal)
    }

    .el-table-v2 {
      font-size: 14px
    }

    .el-table-v2 * {
      box-sizing: border-box
    }

    .el-table-v2__root {
      position: relative
    }

    .el-table-v2__root:hover .el-table-v2__main .el-virtual-scrollbar {
      opacity: 1
    }

    .el-table-v2__main {
      display: flex;
      flex-direction: column-reverse;
      position: absolute;
      overflow: hidden;
      top: 0;
      background-color: var(--el-bg-color);
      left: 0
    }

    .el-table-v2__main .el-vl__horizontal,
    .el-table-v2__main .el-vl__vertical {
      z-index: 2
    }

    .el-table-v2__left {
      display: flex;
      flex-direction: column-reverse;
      position: absolute;
      overflow: hidden;
      top: 0;
      background-color: var(--el-bg-color);
      left: 0;
      box-shadow: 2px 0 4px 0 rgba(0, 0, 0, .06)
    }

    .el-table-v2__left .el-virtual-scrollbar {
      opacity: 0
    }

    .el-table-v2__left .el-vl__horizontal,
    .el-table-v2__left .el-vl__vertical {
      z-index: -1
    }

    .el-table-v2__right {
      display: flex;
      flex-direction: column-reverse;
      position: absolute;
      overflow: hidden;
      top: 0;
      background-color: var(--el-bg-color);
      right: 0;
      box-shadow: -2px 0 4px 0 rgba(0, 0, 0, .06)
    }

    .el-table-v2__right .el-virtual-scrollbar {
      opacity: 0
    }

    .el-table-v2__right .el-vl__horizontal,
    .el-table-v2__right .el-vl__vertical {
      z-index: -1
    }

    .el-table-v2__header-row {
      -webkit-padding-end: var(--el-table-scrollbar-size);
      padding-inline-end: var(--el-table-scrollbar-size)
    }

    .el-table-v2__row {
      -webkit-padding-end: var(--el-table-scrollbar-size);
      padding-inline-end: var(--el-table-scrollbar-size)
    }

    .el-table-v2__header-wrapper {
      overflow: hidden
    }

    .el-table-v2__header {
      position: relative;
      overflow: hidden
    }

    .el-table-v2__footer {
      position: absolute;
      left: 0;
      right: 0;
      bottom: 0;
      overflow: hidden
    }

    .el-table-v2__empty {
      position: absolute;
      left: 0
    }

    .el-table-v2__overlay {
      position: absolute;
      left: 0;
      right: 0;
      top: 0;
      bottom: 0;
      z-index: 9999
    }

    .el-table-v2__header-row {
      display: flex;
      border-bottom: var(--el-table-border)
    }

    .el-table-v2__header-cell {
      display: flex;
      align-items: center;
      padding: 0 8px;
      height: 100%;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      overflow: hidden;
      background-color: var(--el-table-header-bg-color);
      color: var(--el-table-header-text-color);
      font-weight: 700
    }

    .el-table-v2__header-cell.is-align-center {
      justify-content: center;
      text-align: center
    }

    .el-table-v2__header-cell.is-align-right {
      justify-content: flex-end;
      text-align: right
    }

    .el-table-v2__header-cell.is-sortable {
      cursor: pointer
    }

    .el-table-v2__header-cell:hover .el-icon {
      display: block
    }

    .el-table-v2__sort-icon {
      transition: opacity, display var(--el-transition-duration);
      opacity: .6;
      display: none
    }

    .el-table-v2__sort-icon.is-sorting {
      display: block;
      opacity: 1
    }

    .el-table-v2__row {
      border-bottom: var(--el-table-border);
      display: flex;
      align-items: center;
      transition: background-color var(--el-transition-duration)
    }

    .el-table-v2__row.is-hovered {
      background-color: var(--el-table-row-hover-bg-color)
    }

    .el-table-v2__row:hover {
      background-color: var(--el-table-row-hover-bg-color)
    }

    .el-table-v2__row-cell {
      height: 100%;
      overflow: hidden;
      display: flex;
      align-items: center;
      padding: 0 8px
    }

    .el-table-v2__row-cell.is-align-center {
      justify-content: center;
      text-align: center
    }

    .el-table-v2__row-cell.is-align-right {
      justify-content: flex-end;
      text-align: right
    }

    .el-table-v2__expand-icon {
      margin: 0 4px;
      cursor: pointer;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-table-v2__expand-icon svg {
      transition: transform var(--el-transition-duration)
    }

    .el-table-v2__expand-icon.is-expanded svg {
      transform: rotate(90deg)
    }

    .el-table-v2:not(.is-dynamic) .el-table-v2__cell-text {
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap
    }

    .el-table-v2.is-dynamic .el-table-v2__row {
      overflow: hidden;
      align-items: stretch
    }

    .el-table-v2.is-dynamic .el-table-v2__row .el-table-v2__row-cell {
      overflow-wrap: break-word
    }

    .el-tabs {
      --el-tabs-header-height: 40px
    }

    .el-tabs__header {
      padding: 0;
      position: relative;
      margin: 0 0 15px
    }

    .el-tabs__active-bar {
      position: absolute;
      bottom: 0;
      left: 0;
      height: 2px;
      background-color: var(--el-color-primary);
      z-index: 1;
      transition: width var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier), transform var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier);
      list-style: none
    }

    .el-tabs__new-tab {
      display: flex;
      align-items: center;
      justify-content: center;
      float: right;
      border: 1px solid var(--el-border-color);
      height: 20px;
      width: 20px;
      line-height: 20px;
      margin: 10px 0 10px 10px;
      border-radius: 3px;
      text-align: center;
      font-size: 12px;
      color: var(--el-text-color-primary);
      cursor: pointer;
      transition: all .15s
    }

    .el-tabs__new-tab .is-icon-plus {
      height: inherit;
      width: inherit;
      transform: scale(.8, .8)
    }

    .el-tabs__new-tab .is-icon-plus svg {
      vertical-align: middle
    }

    .el-tabs__new-tab:hover {
      color: var(--el-color-primary)
    }

    .el-tabs__nav-wrap {
      overflow: hidden;
      margin-bottom: -1px;
      position: relative
    }

    .el-tabs__nav-wrap::after {
      content: """";
      position: absolute;
      left: 0;
      bottom: 0;
      width: 100%;
      height: 2px;
      background-color: var(--el-border-color-light);
      z-index: var(--el-index-normal)
    }

    .el-tabs__nav-wrap.is-scrollable {
      padding: 0 20px;
      box-sizing: border-box
    }

    .el-tabs__nav-scroll {
      overflow: hidden
    }

    .el-tabs__nav-next,
    .el-tabs__nav-prev {
      position: absolute;
      cursor: pointer;
      line-height: 44px;
      font-size: 12px;
      color: var(--el-text-color-secondary);
      width: 20px;
      text-align: center
    }

    .el-tabs__nav-next {
      right: 0
    }

    .el-tabs__nav-prev {
      left: 0
    }

    .el-tabs__nav {
      display: flex;
      white-space: nowrap;
      position: relative;
      transition: transform var(--el-transition-duration);
      float: left;
      z-index: calc(var(--el-index-normal) + 1)
    }

    .el-tabs__nav.is-stretch {
      min-width: 100%;
      display: flex
    }

    .el-tabs__nav.is-stretch>* {
      flex: 1;
      text-align: center
    }

    .el-tabs__item {
      padding: 0 20px;
      height: var(--el-tabs-header-height);
      box-sizing: border-box;
      display: flex;
      align-items: center;
      justify-content: center;
      list-style: none;
      font-size: var(--el-font-size-base);
      font-weight: 500;
      color: var(--el-text-color-primary);
      position: relative
    }

    .el-tabs__item:focus,
    .el-tabs__item:focus:active {
      outline: 0
    }

    .el-tabs__item:focus-visible {
      box-shadow: 0 0 2px 2px var(--el-color-primary) inset;
      border-radius: 3px
    }

    .el-tabs__item .is-icon-close {
      border-radius: 50%;
      text-align: center;
      transition: all var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier);
      margin-left: 5px
    }

    .el-tabs__item .is-icon-close:before {
      transform: scale(.9);
      display: inline-block
    }

    .el-tabs__item .is-icon-close:hover {
      background-color: var(--el-text-color-placeholder);
      color: #fff
    }

    .el-tabs__item.is-active {
      color: var(--el-color-primary)
    }

    .el-tabs__item:hover {
      color: var(--el-color-primary);
      cursor: pointer
    }

    .el-tabs__item.is-disabled {
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-tabs__content {
      overflow: hidden;
      position: relative
    }

    .el-tabs--card>.el-tabs__header {
      border-bottom: 1px solid var(--el-border-color-light);
      height: var(--el-tabs-header-height)
    }

    .el-tabs--card>.el-tabs__header .el-tabs__nav-wrap::after {
      content: none
    }

    .el-tabs--card>.el-tabs__header .el-tabs__nav {
      border: 1px solid var(--el-border-color-light);
      border-bottom: none;
      border-radius: 4px 4px 0 0;
      box-sizing: border-box
    }

    .el-tabs--card>.el-tabs__header .el-tabs__active-bar {
      display: none
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item .is-icon-close {
      position: relative;
      font-size: 12px;
      width: 0;
      height: 14px;
      overflow: hidden;
      right: -2px;
      transform-origin: 100% 50%
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item {
      border-bottom: 1px solid transparent;
      border-left: 1px solid var(--el-border-color-light);
      transition: color var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier), padding var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier)
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item:first-child {
      border-left: none
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item.is-closable:hover {
      padding-left: 13px;
      padding-right: 13px
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item.is-closable:hover .is-icon-close {
      width: 14px
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item.is-active {
      border-bottom-color: var(--el-bg-color)
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item.is-active.is-closable {
      padding-left: 20px;
      padding-right: 20px
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item.is-active.is-closable .is-icon-close {
      width: 14px
    }

    .el-tabs--border-card {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-border-color)
    }

    .el-tabs--border-card>.el-tabs__content {
      padding: 15px
    }

    .el-tabs--border-card>.el-tabs__header {
      background-color: var(--el-fill-color-light);
      border-bottom: 1px solid var(--el-border-color-light);
      margin: 0
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__nav-wrap::after {
      content: none
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item {
      transition: all var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier);
      border: 1px solid transparent;
      margin-top: -1px;
      color: var(--el-text-color-secondary)
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item:first-child {
      margin-left: -1px
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item+.el-tabs__item {
      margin-left: -1px
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item.is-active {
      color: var(--el-color-primary);
      background-color: var(--el-bg-color-overlay);
      border-right-color: var(--el-border-color);
      border-left-color: var(--el-border-color)
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item:not(.is-disabled):hover {
      color: var(--el-color-primary)
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item.is-disabled {
      color: var(--el-disabled-text-color)
    }

    .el-tabs--border-card>.el-tabs__header .is-scrollable .el-tabs__item:first-child {
      margin-left: 0
    }

    .el-tabs--bottom .el-tabs__item.is-bottom:nth-child(2),
    .el-tabs--bottom .el-tabs__item.is-top:nth-child(2),
    .el-tabs--top .el-tabs__item.is-bottom:nth-child(2),
    .el-tabs--top .el-tabs__item.is-top:nth-child(2) {
      padding-left: 0
    }

    .el-tabs--bottom .el-tabs__item.is-bottom:last-child,
    .el-tabs--bottom .el-tabs__item.is-top:last-child,
    .el-tabs--top .el-tabs__item.is-bottom:last-child,
    .el-tabs--top .el-tabs__item.is-top:last-child {
      padding-right: 0
    }

    .el-tabs--bottom .el-tabs--left>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--bottom .el-tabs--right>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--bottom.el-tabs--border-card>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--bottom.el-tabs--card>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--top .el-tabs--left>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--top .el-tabs--right>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--top.el-tabs--border-card>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--top.el-tabs--card>.el-tabs__header .el-tabs__item:nth-child(2) {
      padding-left: 20px
    }

    .el-tabs--bottom .el-tabs--left>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--bottom .el-tabs--right>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--bottom.el-tabs--border-card>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--bottom.el-tabs--card>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--top .el-tabs--left>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--top .el-tabs--right>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--top.el-tabs--border-card>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--top.el-tabs--card>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover {
      padding-left: 13px
    }

    .el-tabs--bottom .el-tabs--left>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--bottom .el-tabs--right>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--bottom.el-tabs--border-card>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--bottom.el-tabs--card>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--top .el-tabs--left>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--top .el-tabs--right>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--top.el-tabs--border-card>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--top.el-tabs--card>.el-tabs__header .el-tabs__item:last-child {
      padding-right: 20px
    }

    .el-tabs--bottom .el-tabs--left>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--bottom .el-tabs--right>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--bottom.el-tabs--border-card>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--bottom.el-tabs--card>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--top .el-tabs--left>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--top .el-tabs--right>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--top.el-tabs--border-card>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--top.el-tabs--card>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover {
      padding-right: 13px
    }

    .el-tabs--bottom .el-tabs__header.is-bottom {
      margin-bottom: 0;
      margin-top: 10px
    }

    .el-tabs--bottom.el-tabs--border-card .el-tabs__header.is-bottom {
      border-bottom: 0;
      border-top: 1px solid var(--el-border-color)
    }

    .el-tabs--bottom.el-tabs--border-card .el-tabs__nav-wrap.is-bottom {
      margin-top: -1px;
      margin-bottom: 0
    }

    .el-tabs--bottom.el-tabs--border-card .el-tabs__item.is-bottom:not(.is-active) {
      border: 1px solid transparent
    }

    .el-tabs--bottom.el-tabs--border-card .el-tabs__item.is-bottom {
      margin: 0 -1px -1px
    }

    .el-tabs--left,
    .el-tabs--right {
      overflow: hidden
    }

    .el-tabs--left .el-tabs__header.is-left,
    .el-tabs--left .el-tabs__header.is-right,
    .el-tabs--left .el-tabs__nav-scroll,
    .el-tabs--left .el-tabs__nav-wrap.is-left,
    .el-tabs--left .el-tabs__nav-wrap.is-right,
    .el-tabs--right .el-tabs__header.is-left,
    .el-tabs--right .el-tabs__header.is-right,
    .el-tabs--right .el-tabs__nav-scroll,
    .el-tabs--right .el-tabs__nav-wrap.is-left,
    .el-tabs--right .el-tabs__nav-wrap.is-right {
      height: 100%
    }

    .el-tabs--left .el-tabs__active-bar.is-left,
    .el-tabs--left .el-tabs__active-bar.is-right,
    .el-tabs--right .el-tabs__active-bar.is-left,
    .el-tabs--right .el-tabs__active-bar.is-right {
      top: 0;
      bottom: auto;
      width: 2px;
      height: auto
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left,
    .el-tabs--left .el-tabs__nav-wrap.is-right,
    .el-tabs--right .el-tabs__nav-wrap.is-left,
    .el-tabs--right .el-tabs__nav-wrap.is-right {
      margin-bottom: 0
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-next,
    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-next,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-next,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-next,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev {
      height: 30px;
      line-height: 30px;
      width: 100%;
      text-align: center;
      cursor: pointer
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-next i,
    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev i,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-next i,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev i,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-next i,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev i,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-next i,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev i {
      transform: rotateZ(90deg)
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev {
      left: auto;
      top: 0
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-next,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-next,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-next,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-next {
      right: auto;
      bottom: 0
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left.is-scrollable,
    .el-tabs--left .el-tabs__nav-wrap.is-right.is-scrollable,
    .el-tabs--right .el-tabs__nav-wrap.is-left.is-scrollable,
    .el-tabs--right .el-tabs__nav-wrap.is-right.is-scrollable {
      padding: 30px 0
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left::after,
    .el-tabs--left .el-tabs__nav-wrap.is-right::after,
    .el-tabs--right .el-tabs__nav-wrap.is-left::after,
    .el-tabs--right .el-tabs__nav-wrap.is-right::after {
      height: 100%;
      width: 2px;
      bottom: auto;
      top: 0
    }

    .el-tabs--left .el-tabs__nav.is-left,
    .el-tabs--left .el-tabs__nav.is-right,
    .el-tabs--right .el-tabs__nav.is-left,
    .el-tabs--right .el-tabs__nav.is-right {
      flex-direction: column
    }

    .el-tabs--left .el-tabs__item.is-left,
    .el-tabs--right .el-tabs__item.is-left {
      justify-content: flex-end
    }

    .el-tabs--left .el-tabs__item.is-right,
    .el-tabs--right .el-tabs__item.is-right {
      justify-content: flex-start
    }

    .el-tabs--left .el-tabs__header.is-left {
      float: left;
      margin-bottom: 0;
      margin-right: 10px
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left {
      margin-right: -1px
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left::after {
      left: auto;
      right: 0
    }

    .el-tabs--left .el-tabs__active-bar.is-left {
      right: 0;
      left: auto
    }

    .el-tabs--left .el-tabs__item.is-left {
      text-align: right
    }

    .el-tabs--left.el-tabs--card .el-tabs__active-bar.is-left {
      display: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__item.is-left {
      border-left: none;
      border-right: 1px solid var(--el-border-color-light);
      border-bottom: none;
      border-top: 1px solid var(--el-border-color-light);
      text-align: left
    }

    .el-tabs--left.el-tabs--card .el-tabs__item.is-left:first-child {
      border-right: 1px solid var(--el-border-color-light);
      border-top: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__item.is-left.is-active {
      border: 1px solid var(--el-border-color-light);
      border-right-color: #fff;
      border-left: none;
      border-bottom: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__item.is-left.is-active:first-child {
      border-top: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__item.is-left.is-active:last-child {
      border-bottom: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__nav {
      border-radius: 4px 0 0 4px;
      border-bottom: 1px solid var(--el-border-color-light);
      border-right: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__new-tab {
      float: none
    }

    .el-tabs--left.el-tabs--border-card .el-tabs__header.is-left {
      border-right: 1px solid var(--el-border-color)
    }

    .el-tabs--left.el-tabs--border-card .el-tabs__item.is-left {
      border: 1px solid transparent;
      margin: -1px 0 -1px -1px
    }

    .el-tabs--left.el-tabs--border-card .el-tabs__item.is-left.is-active {
      border-color: transparent;
      border-top-color: #d1dbe5;
      border-bottom-color: #d1dbe5
    }

    .el-tabs--right .el-tabs__header.is-right {
      float: right;
      margin-bottom: 0;
      margin-left: 10px
    }

    .el-tabs--right .el-tabs__nav-wrap.is-right {
      margin-left: -1px
    }

    .el-tabs--right .el-tabs__nav-wrap.is-right::after {
      left: 0;
      right: auto
    }

    .el-tabs--right .el-tabs__active-bar.is-right {
      left: 0
    }

    .el-tabs--right.el-tabs--card .el-tabs__active-bar.is-right {
      display: none
    }

    .el-tabs--right.el-tabs--card .el-tabs__item.is-right {
      border-bottom: none;
      border-top: 1px solid var(--el-border-color-light)
    }

    .el-tabs--right.el-tabs--card .el-tabs__item.is-right:first-child {
      border-left: 1px solid var(--el-border-color-light);
      border-top: none
    }

    .el-tabs--right.el-tabs--card .el-tabs__item.is-right.is-active {
      border: 1px solid var(--el-border-color-light);
      border-left-color: #fff;
      border-right: none;
      border-bottom: none
    }

    .el-tabs--right.el-tabs--card .el-tabs__item.is-right.is-active:first-child {
      border-top: none
    }

    .el-tabs--right.el-tabs--card .el-tabs__item.is-right.is-active:last-child {
      border-bottom: none
    }

    .el-tabs--right.el-tabs--card .el-tabs__nav {
      border-radius: 0 4px 4px 0;
      border-bottom: 1px solid var(--el-border-color-light);
      border-left: none
    }

    .el-tabs--right.el-tabs--border-card .el-tabs__header.is-right {
      border-left: 1px solid var(--el-border-color)
    }

    .el-tabs--right.el-tabs--border-card .el-tabs__item.is-right {
      border: 1px solid transparent;
      margin: -1px -1px -1px 0
    }

    .el-tabs--right.el-tabs--border-card .el-tabs__item.is-right.is-active {
      border-color: transparent;
      border-top-color: #d1dbe5;
      border-bottom-color: #d1dbe5
    }

    .slideInLeft-transition,
    .slideInRight-transition {
      display: inline-block
    }

    .slideInRight-enter {
      -webkit-animation: slideInRight-enter var(--el-transition-duration);
      animation: slideInRight-enter var(--el-transition-duration)
    }

    .slideInRight-leave {
      position: absolute;
      left: 0;
      right: 0;
      -webkit-animation: slideInRight-leave var(--el-transition-duration);
      animation: slideInRight-leave var(--el-transition-duration)
    }

    .slideInLeft-enter {
      -webkit-animation: slideInLeft-enter var(--el-transition-duration);
      animation: slideInLeft-enter var(--el-transition-duration)
    }

    .slideInLeft-leave {
      position: absolute;
      left: 0;
      right: 0;
      -webkit-animation: slideInLeft-leave var(--el-transition-duration);
      animation: slideInLeft-leave var(--el-transition-duration)
    }

    @-webkit-keyframes slideInRight-enter {
      0% {
        opacity: 0;
        transform-origin: 0 0;
        transform: translateX(100%)
      }

      to {
        opacity: 1;
        transform-origin: 0 0;
        transform: translateX(0)
      }
    }

    @keyframes slideInRight-enter {
      0% {
        opacity: 0;
        transform-origin: 0 0;
        transform: translateX(100%)
      }

      to {
        opacity: 1;
        transform-origin: 0 0;
        transform: translateX(0)
      }
    }

    @-webkit-keyframes slideInRight-leave {
      0% {
        transform-origin: 0 0;
        transform: translateX(0);
        opacity: 1
      }

      100% {
        transform-origin: 0 0;
        transform: translateX(100%);
        opacity: 0
      }
    }

    @keyframes slideInRight-leave {
      0% {
        transform-origin: 0 0;
        transform: translateX(0);
        opacity: 1
      }

      100% {
        transform-origin: 0 0;
        transform: translateX(100%);
        opacity: 0
      }
    }

    @-webkit-keyframes slideInLeft-enter {
      0% {
        opacity: 0;
        transform-origin: 0 0;
        transform: translateX(-100%)
      }

      to {
        opacity: 1;
        transform-origin: 0 0;
        transform: translateX(0)
      }
    }

    @keyframes slideInLeft-enter {
      0% {
        opacity: 0;
        transform-origin: 0 0;
        transform: translateX(-100%)
      }

      to {
        opacity: 1;
        transform-origin: 0 0;
        transform: translateX(0)
      }
    }

    @-webkit-keyframes slideInLeft-leave {
      0% {
        transform-origin: 0 0;
        transform: translateX(0);
        opacity: 1
      }

      100% {
        transform-origin: 0 0;
        transform: translateX(-100%);
        opacity: 0
      }
    }

    @keyframes slideInLeft-leave {
      0% {
        transform-origin: 0 0;
        transform: translateX(0);
        opacity: 1
      }

      100% {
        transform-origin: 0 0;
        transform: translateX(-100%);
        opacity: 0
      }
    }

    .el-tag {
      --el-tag-font-size: 12px;
      --el-tag-border-radius: 4px;
      --el-tag-border-radius-rounded: 9999px
    }

    .el-tag {
      --el-tag-bg-color: var(--el-color-primary-light-9);
      --el-tag-border-color: var(--el-color-primary-light-8);
      --el-tag-hover-color: var(--el-color-primary);
      background-color: var(--el-tag-bg-color);
      border-color: var(--el-tag-border-color);
      color: var(--el-tag-text-color);
      display: inline-flex;
      justify-content: center;
      align-items: center;
      vertical-align: middle;
      height: 24px;
      padding: 0 9px;
      font-size: var(--el-tag-font-size);
      line-height: 1;
      border-width: 1px;
      border-style: solid;
      border-radius: var(--el-tag-border-radius);
      box-sizing: border-box;
      white-space: nowrap;
      --el-icon-size: 14px
    }

    .el-tag.el-tag--primary {
      --el-tag-bg-color: var(--el-color-primary-light-9);
      --el-tag-border-color: var(--el-color-primary-light-8);
      --el-tag-hover-color: var(--el-color-primary)
    }

    .el-tag.el-tag--success {
      --el-tag-bg-color: var(--el-color-success-light-9);
      --el-tag-border-color: var(--el-color-success-light-8);
      --el-tag-hover-color: var(--el-color-success)
    }

    .el-tag.el-tag--warning {
      --el-tag-bg-color: var(--el-color-warning-light-9);
      --el-tag-border-color: var(--el-color-warning-light-8);
      --el-tag-hover-color: var(--el-color-warning)
    }

    .el-tag.el-tag--danger {
      --el-tag-bg-color: var(--el-color-danger-light-9);
      --el-tag-border-color: var(--el-color-danger-light-8);
      --el-tag-hover-color: var(--el-color-danger)
    }

    .el-tag.el-tag--error {
      --el-tag-bg-color: var(--el-color-error-light-9);
      --el-tag-border-color: var(--el-color-error-light-8);
      --el-tag-hover-color: var(--el-color-error)
    }

    .el-tag.el-tag--info {
      --el-tag-bg-color: var(--el-color-info-light-9);
      --el-tag-border-color: var(--el-color-info-light-8);
      --el-tag-hover-color: var(--el-color-info)
    }

    .el-tag.el-tag--primary {
      --el-tag-text-color: var(--el-color-primary)
    }

    .el-tag.el-tag--success {
      --el-tag-text-color: var(--el-color-success)
    }

    .el-tag.el-tag--warning {
      --el-tag-text-color: var(--el-color-warning)
    }

    .el-tag.el-tag--danger {
      --el-tag-text-color: var(--el-color-danger)
    }

    .el-tag.el-tag--error {
      --el-tag-text-color: var(--el-color-error)
    }

    .el-tag.el-tag--info {
      --el-tag-text-color: var(--el-color-info)
    }

    .el-tag.is-hit {
      border-color: var(--el-color-primary)
    }

    .el-tag.is-round {
      border-radius: var(--el-tag-border-radius-rounded)
    }

    .el-tag .el-tag__close {
      flex-shrink: 0;
      color: var(--el-tag-text-color)
    }

    .el-tag .el-tag__close:hover {
      color: var(--el-color-white);
      background-color: var(--el-tag-hover-color)
    }

    .el-tag .el-icon {
      border-radius: 50%;
      cursor: pointer;
      font-size: calc(var(--el-icon-size) - 2px);
      height: var(--el-icon-size);
      width: var(--el-icon-size)
    }

    .el-tag .el-tag__close {
      margin-left: 6px
    }

    .el-tag--dark {
      --el-tag-bg-color: var(--el-color-primary);
      --el-tag-border-color: var(--el-color-primary);
      --el-tag-hover-color: var(--el-color-primary-light-3);
      --el-tag-text-color: var(--el-color-white);
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--primary {
      --el-tag-bg-color: var(--el-color-primary);
      --el-tag-border-color: var(--el-color-primary);
      --el-tag-hover-color: var(--el-color-primary-light-3)
    }

    .el-tag--dark.el-tag--success {
      --el-tag-bg-color: var(--el-color-success);
      --el-tag-border-color: var(--el-color-success);
      --el-tag-hover-color: var(--el-color-success-light-3)
    }

    .el-tag--dark.el-tag--warning {
      --el-tag-bg-color: var(--el-color-warning);
      --el-tag-border-color: var(--el-color-warning);
      --el-tag-hover-color: var(--el-color-warning-light-3)
    }

    .el-tag--dark.el-tag--danger {
      --el-tag-bg-color: var(--el-color-danger);
      --el-tag-border-color: var(--el-color-danger);
      --el-tag-hover-color: var(--el-color-danger-light-3)
    }

    .el-tag--dark.el-tag--error {
      --el-tag-bg-color: var(--el-color-error);
      --el-tag-border-color: var(--el-color-error);
      --el-tag-hover-color: var(--el-color-error-light-3)
    }

    .el-tag--dark.el-tag--info {
      --el-tag-bg-color: var(--el-color-info);
      --el-tag-border-color: var(--el-color-info);
      --el-tag-hover-color: var(--el-color-info-light-3)
    }

    .el-tag--dark.el-tag--primary {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--success {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--warning {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--danger {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--error {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--info {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--plain {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-primary-light-5);
      --el-tag-hover-color: var(--el-color-primary);
      --el-tag-bg-color: var(--el-fill-color-blank)
    }

    .el-tag--plain.el-tag--primary {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-primary-light-5);
      --el-tag-hover-color: var(--el-color-primary)
    }

    .el-tag--plain.el-tag--success {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-success-light-5);
      --el-tag-hover-color: var(--el-color-success)
    }

    .el-tag--plain.el-tag--warning {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-warning-light-5);
      --el-tag-hover-color: var(--el-color-warning)
    }

    .el-tag--plain.el-tag--danger {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-danger-light-5);
      --el-tag-hover-color: var(--el-color-danger)
    }

    .el-tag--plain.el-tag--error {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-error-light-5);
      --el-tag-hover-color: var(--el-color-error)
    }

    .el-tag--plain.el-tag--info {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-info-light-5);
      --el-tag-hover-color: var(--el-color-info)
    }

    .el-tag.is-closable {
      padding-right: 5px
    }

    .el-tag--large {
      padding: 0 11px;
      height: 32px;
      --el-icon-size: 16px
    }

    .el-tag--large .el-tag__close {
      margin-left: 8px
    }

    .el-tag--large.is-closable {
      padding-right: 7px
    }

    .el-tag--small {
      padding: 0 7px;
      height: 20px;
      --el-icon-size: 12px
    }

    .el-tag--small .el-tag__close {
      margin-left: 4px
    }

    .el-tag--small.is-closable {
      padding-right: 3px
    }

    .el-tag--small .el-icon-close {
      transform: scale(.8)
    }

    .el-tag.el-tag--primary.is-hit {
      border-color: var(--el-color-primary)
    }

    .el-tag.el-tag--success.is-hit {
      border-color: var(--el-color-success)
    }

    .el-tag.el-tag--warning.is-hit {
      border-color: var(--el-color-warning)
    }

    .el-tag.el-tag--danger.is-hit {
      border-color: var(--el-color-danger)
    }

    .el-tag.el-tag--error.is-hit {
      border-color: var(--el-color-error)
    }

    .el-tag.el-tag--info.is-hit {
      border-color: var(--el-color-info)
    }

    .el-text {
      --el-text-font-size: var(--el-font-size-base);
      --el-text-color: var(--el-text-color-regular)
    }

    .el-text {
      align-self: center;
      margin: 0;
      padding: 0;
      font-size: var(--el-text-font-size);
      color: var(--el-text-color);
      overflow-wrap: break-word
    }

    .el-text.is-truncated {
      display: inline-block;
      max-width: 100%;
      text-overflow: ellipsis;
      white-space: nowrap;
      overflow: hidden
    }

    .el-text.is-line-clamp {
      display: -webkit-inline-box;
      -webkit-box-orient: vertical;
      overflow: hidden
    }

    .el-text--large {
      --el-text-font-size: var(--el-font-size-medium)
    }

    .el-text--default {
      --el-text-font-size: var(--el-font-size-base)
    }

    .el-text--small {
      --el-text-font-size: var(--el-font-size-extra-small)
    }

    .el-text.el-text--primary {
      --el-text-color: var(--el-color-primary)
    }

    .el-text.el-text--success {
      --el-text-color: var(--el-color-success)
    }

    .el-text.el-text--warning {
      --el-text-color: var(--el-color-warning)
    }

    .el-text.el-text--danger {
      --el-text-color: var(--el-color-danger)
    }

    .el-text.el-text--error {
      --el-text-color: var(--el-color-error)
    }

    .el-text.el-text--info {
      --el-text-color: var(--el-color-info)
    }

    .el-text>.el-icon {
      vertical-align: -2px
    }

    .time-select {
      margin: 5px 0;
      min-width: 0
    }

    .time-select .el-picker-panel__content {
      max-height: 200px;
      margin: 0
    }

    .time-select-item {
      padding: 8px 10px;
      font-size: 14px;
      line-height: 20px
    }

    .time-select-item.disabled {
      color: var(--el-datepicker-border-color);
      cursor: not-allowed
    }

    .time-select-item:hover {
      background-color: var(--el-fill-color-light);
      font-weight: 700;
      cursor: pointer
    }

    .time-select .time-select-item.selected:not(.disabled) {
      color: var(--el-color-primary);
      font-weight: 700
    }

    .el-timeline-item {
      position: relative;
      padding-bottom: 20px
    }

    .el-timeline-item__wrapper {
      position: relative;
      padding-left: 28px;
      top: -3px
    }

    .el-timeline-item__tail {
      position: absolute;
      left: 4px;
      height: 100%;
      border-left: 2px solid var(--el-timeline-node-color)
    }

    .el-timeline-item .el-timeline-item__icon {
      color: var(--el-color-white);
      font-size: var(--el-font-size-small)
    }

    .el-timeline-item__node {
      position: absolute;
      background-color: var(--el-timeline-node-color);
      border-color: var(--el-timeline-node-color);
      border-radius: 50%;
      box-sizing: border-box;
      display: flex;
      justify-content: center;
      align-items: center
    }

    .el-timeline-item__node--normal {
      left: -1px;
      width: var(--el-timeline-node-size-normal);
      height: var(--el-timeline-node-size-normal)
    }

    .el-timeline-item__node--large {
      left: -2px;
      width: var(--el-timeline-node-size-large);
      height: var(--el-timeline-node-size-large)
    }

    .el-timeline-item__node.is-hollow {
      background: var(--el-color-white);
      border-style: solid;
      border-width: 2px
    }

    .el-timeline-item__node--primary {
      background-color: var(--el-color-primary);
      border-color: var(--el-color-primary)
    }

    .el-timeline-item__node--success {
      background-color: var(--el-color-success);
      border-color: var(--el-color-success)
    }

    .el-timeline-item__node--warning {
      background-color: var(--el-color-warning);
      border-color: var(--el-color-warning)
    }

    .el-timeline-item__node--danger {
      background-color: var(--el-color-danger);
      border-color: var(--el-color-danger)
    }

    .el-timeline-item__node--info {
      background-color: var(--el-color-info);
      border-color: var(--el-color-info)
    }

    .el-timeline-item__dot {
      position: absolute;
      display: flex;
      justify-content: center;
      align-items: center
    }

    .el-timeline-item__content {
      color: var(--el-text-color-primary)
    }

    .el-timeline-item__timestamp {
      color: var(--el-text-color-secondary);
      line-height: 1;
      font-size: var(--el-font-size-small)
    }

    .el-timeline-item__timestamp.is-top {
      margin-bottom: 8px;
      padding-top: 4px
    }

    .el-timeline-item__timestamp.is-bottom {
      margin-top: 8px
    }

    .el-timeline {
      --el-timeline-node-size-normal: 12px;
      --el-timeline-node-size-large: 14px;
      --el-timeline-node-color: var(--el-border-color-light)
    }

    .el-timeline {
      margin: 0;
      font-size: var(--el-font-size-base);
      list-style: none
    }

    .el-timeline .el-timeline-item:last-child .el-timeline-item__tail {
      display: none
    }

    .el-timeline .el-timeline-item__center {
      display: flex;
      align-items: center
    }

    .el-timeline .el-timeline-item__center .el-timeline-item__wrapper {
      width: 100%
    }

    .el-timeline .el-timeline-item__center .el-timeline-item__tail {
      top: 0
    }

    .el-timeline .el-timeline-item__center:first-child .el-timeline-item__tail {
      height: calc(50% + 10px);
      top: calc(50% - 10px)
    }

    .el-timeline .el-timeline-item__center:last-child .el-timeline-item__tail {
      display: block;
      height: calc(50% - 10px)
    }

    .el-tooltip-v2__content {
      --el-tooltip-v2-padding: 5px 10px;
      --el-tooltip-v2-border-radius: 4px;
      --el-tooltip-v2-border-color: var(--el-border-color);
      border-radius: var(--el-tooltip-v2-border-radius);
      color: var(--el-color-black);
      background-color: var(--el-color-white);
      padding: var(--el-tooltip-v2-padding);
      border: 1px solid var(--el-border-color)
    }

    .el-tooltip-v2__arrow {
      position: absolute;
      color: var(--el-color-white);
      width: var(--el-tooltip-v2-arrow-width);
      height: var(--el-tooltip-v2-arrow-height);
      pointer-events: none;
      left: var(--el-tooltip-v2-arrow-x);
      top: var(--el-tooltip-v2-arrow-y)
    }

    .el-tooltip-v2__arrow::before {
      content: """";
      width: 0;
      height: 0;
      border: var(--el-tooltip-v2-arrow-border-width) solid transparent;
      position: absolute
    }

    .el-tooltip-v2__arrow::after {
      content: """";
      width: 0;
      height: 0;
      border: var(--el-tooltip-v2-arrow-border-width) solid transparent;
      position: absolute
    }

    .el-tooltip-v2__content[data-side^=top] .el-tooltip-v2__arrow {
      bottom: 0
    }

    .el-tooltip-v2__content[data-side^=top] .el-tooltip-v2__arrow::before {
      border-top-color: var(--el-color-white);
      border-top-width: var(--el-tooltip-v2-arrow-border-width);
      border-bottom: 0;
      top: calc(100% - 1px)
    }

    .el-tooltip-v2__content[data-side^=top] .el-tooltip-v2__arrow::after {
      border-top-color: var(--el-border-color);
      border-top-width: var(--el-tooltip-v2-arrow-border-width);
      border-bottom: 0;
      top: 100%;
      z-index: -1
    }

    .el-tooltip-v2__content[data-side^=bottom] .el-tooltip-v2__arrow {
      top: 0
    }

    .el-tooltip-v2__content[data-side^=bottom] .el-tooltip-v2__arrow::before {
      border-bottom-color: var(--el-color-white);
      border-bottom-width: var(--el-tooltip-v2-arrow-border-width);
      border-top: 0;
      bottom: calc(100% - 1px)
    }

    .el-tooltip-v2__content[data-side^=bottom] .el-tooltip-v2__arrow::after {
      border-bottom-color: var(--el-border-color);
      border-bottom-width: var(--el-tooltip-v2-arrow-border-width);
      border-top: 0;
      bottom: 100%;
      z-index: -1
    }

    .el-tooltip-v2__content[data-side^=left] .el-tooltip-v2__arrow {
      right: 0
    }

    .el-tooltip-v2__content[data-side^=left] .el-tooltip-v2__arrow::before {
      border-left-color: var(--el-color-white);
      border-left-width: var(--el-tooltip-v2-arrow-border-width);
      border-right: 0;
      left: calc(100% - 1px)
    }

    .el-tooltip-v2__content[data-side^=left] .el-tooltip-v2__arrow::after {
      border-left-color: var(--el-border-color);
      border-left-width: var(--el-tooltip-v2-arrow-border-width);
      border-right: 0;
      left: 100%;
      z-index: -1
    }

    .el-tooltip-v2__content[data-side^=right] .el-tooltip-v2__arrow {
      left: 0
    }

    .el-tooltip-v2__content[data-side^=right] .el-tooltip-v2__arrow::before {
      border-right-color: var(--el-color-white);
      border-right-width: var(--el-tooltip-v2-arrow-border-width);
      border-left: 0;
      right: calc(100% - 1px)
    }

    .el-tooltip-v2__content[data-side^=right] .el-tooltip-v2__arrow::after {
      border-right-color: var(--el-border-color);
      border-right-width: var(--el-tooltip-v2-arrow-border-width);
      border-left: 0;
      right: 100%;
      z-index: -1
    }

    .el-tooltip-v2__content.is-dark {
      --el-tooltip-v2-border-color: transparent;
      background-color: var(--el-color-black);
      color: var(--el-color-white);
      border-color: transparent
    }

    .el-tooltip-v2__content.is-dark .el-tooltip-v2__arrow {
      background-color: var(--el-color-black);
      border-color: transparent
    }

    .el-transfer {
      --el-transfer-border-color: var(--el-border-color-lighter);
      --el-transfer-border-radius: var(--el-border-radius-base);
      --el-transfer-panel-width: 200px;
      --el-transfer-panel-header-height: 40px;
      --el-transfer-panel-header-bg-color: var(--el-fill-color-light);
      --el-transfer-panel-footer-height: 40px;
      --el-transfer-panel-body-height: 278px;
      --el-transfer-item-height: 30px;
      --el-transfer-filter-height: 32px
    }

    .el-transfer {
      font-size: var(--el-font-size-base)
    }

    .el-transfer__buttons {
      display: inline-block;
      vertical-align: middle;
      padding: 0 30px
    }

    .el-transfer__button {
      vertical-align: top
    }

    .el-transfer__button:nth-child(2) {
      margin: 0 0 0 10px
    }

    .el-transfer__button i,
    .el-transfer__button span {
      font-size: 14px
    }

    .el-transfer__button .el-icon+span {
      margin-left: 0
    }

    .el-transfer-panel {
      overflow: hidden;
      background: var(--el-bg-color-overlay);
      display: inline-block;
      text-align: left;
      vertical-align: middle;
      width: var(--el-transfer-panel-width);
      max-height: 100%;
      box-sizing: border-box;
      position: relative
    }

    .el-transfer-panel__body {
      height: var(--el-transfer-panel-body-height);
      border-left: 1px solid var(--el-transfer-border-color);
      border-right: 1px solid var(--el-transfer-border-color);
      border-bottom: 1px solid var(--el-transfer-border-color);
      border-bottom-left-radius: var(--el-transfer-border-radius);
      border-bottom-right-radius: var(--el-transfer-border-radius);
      overflow: hidden
    }

    .el-transfer-panel__body.is-with-footer {
      border-bottom: none;
      border-bottom-left-radius: 0;
      border-bottom-right-radius: 0
    }

    .el-transfer-panel__list {
      margin: 0;
      padding: 6px 0;
      list-style: none;
      height: var(--el-transfer-panel-body-height);
      overflow: auto;
      box-sizing: border-box
    }

    .el-transfer-panel__list.is-filterable {
      height: calc(100% - var(--el-transfer-filter-height) - 30px);
      padding-top: 0
    }

    .el-transfer-panel__item {
      height: var(--el-transfer-item-height);
      line-height: var(--el-transfer-item-height);
      padding-left: 15px;
      display: block !important
    }

    .el-transfer-panel__item+.el-transfer-panel__item {
      margin-left: 0
    }

    .el-transfer-panel__item.el-checkbox {
      color: var(--el-text-color-regular)
    }

    .el-transfer-panel__item:hover {
      color: var(--el-color-primary)
    }

    .el-transfer-panel__item.el-checkbox .el-checkbox__label {
      width: 100%;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap;
      display: block;
      box-sizing: border-box;
      padding-left: 22px;
      line-height: var(--el-transfer-item-height)
    }

    .el-transfer-panel__item .el-checkbox__input {
      position: absolute;
      top: 8px
    }

    .el-transfer-panel__filter {
      text-align: center;
      padding: 15px;
      box-sizing: border-box
    }

    .el-transfer-panel__filter .el-input__inner {
      height: var(--el-transfer-filter-height);
      width: 100%;
      font-size: 12px;
      display: inline-block;
      box-sizing: border-box;
      border-radius: calc(var(--el-transfer-filter-height)/ 2)
    }

    .el-transfer-panel__filter .el-icon-circle-close {
      cursor: pointer
    }

    .el-transfer-panel .el-transfer-panel__header {
      display: flex;
      align-items: center;
      height: var(--el-transfer-panel-header-height);
      background: var(--el-transfer-panel-header-bg-color);
      margin: 0;
      padding-left: 15px;
      border: 1px solid var(--el-transfer-border-color);
      border-top-left-radius: var(--el-transfer-border-radius);
      border-top-right-radius: var(--el-transfer-border-radius);
      box-sizing: border-box;
      color: var(--el-color-black)
    }

    .el-transfer-panel .el-transfer-panel__header .el-checkbox {
      position: relative;
      display: flex;
      width: 100%;
      align-items: center
    }

    .el-transfer-panel .el-transfer-panel__header .el-checkbox .el-checkbox__label {
      font-size: 16px;
      color: var(--el-text-color-primary);
      font-weight: 400
    }

    .el-transfer-panel .el-transfer-panel__header .el-checkbox .el-checkbox__label span {
      position: absolute;
      right: 15px;
      top: 50%;
      transform: translate3d(0, -50%, 0);
      color: var(--el-text-color-secondary);
      font-size: 12px;
      font-weight: 400
    }

    .el-transfer-panel .el-transfer-panel__footer {
      height: var(--el-transfer-panel-footer-height);
      background: var(--el-bg-color-overlay);
      margin: 0;
      padding: 0;
      border: 1px solid var(--el-transfer-border-color);
      border-bottom-left-radius: var(--el-transfer-border-radius);
      border-bottom-right-radius: var(--el-transfer-border-radius)
    }

    .el-transfer-panel .el-transfer-panel__footer::after {
      display: inline-block;
      content: """";
      height: 100%;
      vertical-align: middle
    }

    .el-transfer-panel .el-transfer-panel__footer .el-checkbox {
      padding-left: 20px;
      color: var(--el-text-color-regular)
    }

    .el-transfer-panel .el-transfer-panel__empty {
      margin: 0;
      height: var(--el-transfer-item-height);
      line-height: var(--el-transfer-item-height);
      padding: 6px 15px 0;
      color: var(--el-text-color-secondary);
      text-align: center
    }

    .el-transfer-panel .el-checkbox__label {
      padding-left: 8px
    }

    .el-transfer-panel .el-checkbox__inner {
      height: 14px;
      width: 14px;
      border-radius: 3px
    }

    .el-transfer-panel .el-checkbox__inner::after {
      height: 6px;
      width: 3px;
      left: 4px
    }

    .el-tree {
      --el-tree-node-content-height: 26px;
      --el-tree-node-hover-bg-color: var(--el-fill-color-light);
      --el-tree-text-color: var(--el-text-color-regular);
      --el-tree-expand-icon-color: var(--el-text-color-placeholder)
    }

    .el-tree {
      position: relative;
      cursor: default;
      background: var(--el-fill-color-blank);
      color: var(--el-tree-text-color);
      font-size: var(--el-font-size-base)
    }

    .el-tree__empty-block {
      position: relative;
      min-height: 60px;
      text-align: center;
      width: 100%;
      height: 100%
    }

    .el-tree__empty-text {
      position: absolute;
      left: 50%;
      top: 50%;
      transform: translate(-50%, -50%);
      color: var(--el-text-color-secondary);
      font-size: var(--el-font-size-base)
    }

    .el-tree__drop-indicator {
      position: absolute;
      left: 0;
      right: 0;
      height: 1px;
      background-color: var(--el-color-primary)
    }

    .el-tree-node {
      white-space: nowrap;
      outline: 0
    }

    .el-tree-node:focus>.el-tree-node__content {
      background-color: var(--el-tree-node-hover-bg-color)
    }

    .el-tree-node.is-drop-inner>.el-tree-node__content .el-tree-node__label {
      background-color: var(--el-color-primary);
      color: #fff
    }

    .el-tree-node__content {
      --el-checkbox-height: var(--el-tree-node-content-height);
      display: flex;
      align-items: center;
      height: var(--el-tree-node-content-height);
      cursor: pointer
    }

    .el-tree-node__content>.el-tree-node__expand-icon {
      padding: 6px;
      box-sizing: content-box
    }

    .el-tree-node__content>label.el-checkbox {
      margin-right: 8px
    }

    .el-tree-node__content:hover {
      background-color: var(--el-tree-node-hover-bg-color)
    }

    .el-tree.is-dragging .el-tree-node__content {
      cursor: move
    }

    .el-tree.is-dragging .el-tree-node__content * {
      pointer-events: none
    }

    .el-tree.is-dragging.is-drop-not-allow .el-tree-node__content {
      cursor: not-allowed
    }

    .el-tree-node__expand-icon {
      cursor: pointer;
      color: var(--el-tree-expand-icon-color);
      font-size: 12px;
      transform: rotate(0);
      transition: transform var(--el-transition-duration) ease-in-out
    }

    .el-tree-node__expand-icon.expanded {
      transform: rotate(90deg)
    }

    .el-tree-node__expand-icon.is-leaf {
      color: transparent;
      cursor: default;
      visibility: hidden
    }

    .el-tree-node__expand-icon.is-hidden {
      visibility: hidden
    }

    .el-tree-node__loading-icon {
      margin-right: 8px;
      font-size: var(--el-font-size-base);
      color: var(--el-tree-expand-icon-color)
    }

    .el-tree-node>.el-tree-node__children {
      overflow: hidden;
      background-color: transparent
    }

    .el-tree-node.is-expanded>.el-tree-node__children {
      display: block
    }

    .el-tree--highlight-current .el-tree-node.is-current>.el-tree-node__content {
      background-color: var(--el-color-primary-light-9)
    }

    .el-tree-select {
      --el-tree-node-content-height: 26px;
      --el-tree-node-hover-bg-color: var(--el-fill-color-light);
      --el-tree-text-color: var(--el-text-color-regular);
      --el-tree-expand-icon-color: var(--el-text-color-placeholder)
    }

    .el-tree-select__popper .el-tree-node__expand-icon {
      margin-left: 8px
    }

    .el-tree-select__popper .el-tree-node.is-checked>.el-tree-node__content .el-select-dropdown__item.selected::after {
      content: none
    }

    .el-tree-select__popper .el-select-dropdown__item {
      flex: 1;
      background: 0 0 !important;
      padding-left: 0;
      height: 20px;
      line-height: 20px
    }

    .el-upload {
      --el-upload-dragger-padding-horizontal: 40px;
      --el-upload-dragger-padding-vertical: 10px
    }

    .el-upload {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      cursor: pointer;
      outline: 0
    }

    .el-upload__input {
      display: none
    }

    .el-upload__tip {
      font-size: 12px;
      color: var(--el-text-color-regular);
      margin-top: 7px
    }

    .el-upload iframe {
      position: absolute;
      z-index: -1;
      top: 0;
      left: 0;
      opacity: 0
    }

    .el-upload--picture-card {
      --el-upload-picture-card-size: 148px;
      background-color: var(--el-fill-color-lighter);
      border: 1px dashed var(--el-border-color-darker);
      border-radius: 6px;
      box-sizing: border-box;
      width: var(--el-upload-picture-card-size);
      height: var(--el-upload-picture-card-size);
      cursor: pointer;
      vertical-align: top;
      display: inline-flex;
      justify-content: center;
      align-items: center
    }

    .el-upload--picture-card>i {
      font-size: 28px;
      color: var(--el-text-color-secondary)
    }

    .el-upload--picture-card:hover {
      border-color: var(--el-color-primary);
      color: var(--el-color-primary)
    }

    .el-upload.is-drag {
      display: block
    }

    .el-upload:focus {
      border-color: var(--el-color-primary);
      color: var(--el-color-primary)
    }

    .el-upload:focus .el-upload-dragger {
      border-color: var(--el-color-primary)
    }

    .el-upload-dragger {
      padding: var(--el-upload-dragger-padding-horizontal) var(--el-upload-dragger-padding-vertical);
      background-color: var(--el-fill-color-blank);
      border: 1px dashed var(--el-border-color);
      border-radius: 6px;
      box-sizing: border-box;
      text-align: center;
      cursor: pointer;
      position: relative;
      overflow: hidden
    }

    .el-upload-dragger .el-icon--upload {
      font-size: 67px;
      color: var(--el-text-color-placeholder);
      margin-bottom: 16px;
      line-height: 50px
    }

    .el-upload-dragger+.el-upload__tip {
      text-align: center
    }

    .el-upload-dragger~.el-upload__files {
      border-top: var(--el-border);
      margin-top: 7px;
      padding-top: 5px
    }

    .el-upload-dragger .el-upload__text {
      color: var(--el-text-color-regular);
      font-size: 14px;
      text-align: center
    }

    .el-upload-dragger .el-upload__text em {
      color: var(--el-color-primary);
      font-style: normal
    }

    .el-upload-dragger:hover {
      border-color: var(--el-color-primary)
    }

    .el-upload-dragger.is-dragover {
      padding: calc(var(--el-upload-dragger-padding-horizontal) - 1px) calc(var(--el-upload-dragger-padding-vertical) - 1px);
      background-color: var(--el-color-primary-light-9);
      border: 2px dashed var(--el-color-primary)
    }

    .el-upload-list {
      margin: 10px 0 0;
      padding: 0;
      list-style: none;
      position: relative
    }

    .el-upload-list__item {
      transition: all .5s cubic-bezier(.55, 0, .1, 1);
      font-size: 14px;
      color: var(--el-text-color-regular);
      margin-bottom: 5px;
      position: relative;
      box-sizing: border-box;
      border-radius: 4px;
      width: 100%
    }

    .el-upload-list__item .el-progress {
      position: absolute;
      top: 20px;
      width: 100%
    }

    .el-upload-list__item .el-progress__text {
      position: absolute;
      right: 0;
      top: -13px
    }

    .el-upload-list__item .el-progress-bar {
      margin-right: 0;
      padding-right: 0
    }

    .el-upload-list__item .el-icon--upload-success {
      color: var(--el-color-success)
    }

    .el-upload-list__item .el-icon--close {
      display: none;
      position: absolute;
      right: 5px;
      top: 50%;
      cursor: pointer;
      opacity: .75;
      color: var(--el-text-color-regular);
      transition: opacity var(--el-transition-duration);
      transform: translateY(-50%)
    }

    .el-upload-list__item .el-icon--close:hover {
      opacity: 1;
      color: var(--el-color-primary)
    }

    .el-upload-list__item .el-icon--close-tip {
      display: none;
      position: absolute;
      top: 1px;
      right: 5px;
      font-size: 12px;
      cursor: pointer;
      opacity: 1;
      color: var(--el-color-primary);
      font-style: normal
    }

    .el-upload-list__item:hover {
      background-color: var(--el-fill-color-light)
    }

    .el-upload-list__item:hover .el-icon--close {
      display: inline-flex
    }

    .el-upload-list__item:hover .el-progress__text {
      display: none
    }

    .el-upload-list__item .el-upload-list__item-info {
      display: inline-flex;
      justify-content: center;
      flex-direction: column;
      width: calc(100% - 30px);
      margin-left: 4px
    }

    .el-upload-list__item.is-success .el-upload-list__item-status-label {
      display: inline-flex
    }

    .el-upload-list__item.is-success .el-upload-list__item-name:focus,
    .el-upload-list__item.is-success .el-upload-list__item-name:hover {
      color: var(--el-color-primary);
      cursor: pointer
    }

    .el-upload-list__item.is-success:focus:not(:hover) .el-icon--close-tip {
      display: inline-block
    }

    .el-upload-list__item.is-success:active,
    .el-upload-list__item.is-success:not(.focusing):focus {
      outline-width: 0
    }

    .el-upload-list__item.is-success:active .el-icon--close-tip,
    .el-upload-list__item.is-success:not(.focusing):focus .el-icon--close-tip {
      display: none
    }

    .el-upload-list__item.is-success:focus .el-upload-list__item-status-label,
    .el-upload-list__item.is-success:hover .el-upload-list__item-status-label {
      display: none;
      opacity: 0
    }

    .el-upload-list__item-name {
      color: var(--el-text-color-regular);
      display: inline-flex;
      text-align: center;
      align-items: center;
      padding: 0 4px;
      transition: color var(--el-transition-duration);
      font-size: var(--el-font-size-base)
    }

    .el-upload-list__item-name .el-icon {
      margin-right: 6px;
      color: var(--el-text-color-secondary)
    }

    .el-upload-list__item-file-name {
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap
    }

    .el-upload-list__item-status-label {
      position: absolute;
      right: 5px;
      top: 0;
      line-height: inherit;
      display: none;
      height: 100%;
      justify-content: center;
      align-items: center;
      transition: opacity var(--el-transition-duration)
    }

    .el-upload-list__item-delete {
      position: absolute;
      right: 10px;
      top: 0;
      font-size: 12px;
      color: var(--el-text-color-regular);
      display: none
    }

    .el-upload-list__item-delete:hover {
      color: var(--el-color-primary)
    }

    .el-upload-list--picture-card {
      --el-upload-list-picture-card-size: 148px;
      display: inline-flex;
      flex-wrap: wrap;
      margin: 0
    }

    .el-upload-list--picture-card .el-upload-list__item {
      overflow: hidden;
      background-color: var(--el-fill-color-blank);
      border: 1px solid var(--el-border-color);
      border-radius: 6px;
      box-sizing: border-box;
      width: var(--el-upload-list-picture-card-size);
      height: var(--el-upload-list-picture-card-size);
      margin: 0 8px 8px 0;
      padding: 0;
      display: inline-flex
    }

    .el-upload-list--picture-card .el-upload-list__item .el-icon--check,
    .el-upload-list--picture-card .el-upload-list__item .el-icon--circle-check {
      color: #fff
    }

    .el-upload-list--picture-card .el-upload-list__item .el-icon--close {
      display: none
    }

    .el-upload-list--picture-card .el-upload-list__item:hover .el-upload-list__item-status-label {
      opacity: 0;
      display: block
    }

    .el-upload-list--picture-card .el-upload-list__item:hover .el-progress__text {
      display: block
    }

    .el-upload-list--picture-card .el-upload-list__item .el-upload-list__item-name {
      display: none
    }

    .el-upload-list--picture-card .el-upload-list__item-thumbnail {
      width: 100%;
      height: 100%;
      -o-object-fit: contain;
      object-fit: contain
    }

    .el-upload-list--picture-card .el-upload-list__item-status-label {
      right: -15px;
      top: -6px;
      width: 40px;
      height: 24px;
      background: var(--el-color-success);
      text-align: center;
      transform: rotate(45deg)
    }

    .el-upload-list--picture-card .el-upload-list__item-status-label i {
      font-size: 12px;
      margin-top: 11px;
      transform: rotate(-45deg)
    }

    .el-upload-list--picture-card .el-upload-list__item-actions {
      position: absolute;
      width: 100%;
      height: 100%;
      left: 0;
      top: 0;
      cursor: default;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      color: #fff;
      opacity: 0;
      font-size: 20px;
      background-color: var(--el-overlay-color-lighter);
      transition: opacity var(--el-transition-duration)
    }

    .el-upload-list--picture-card .el-upload-list__item-actions span {
      display: none;
      cursor: pointer
    }

    .el-upload-list--picture-card .el-upload-list__item-actions span+span {
      margin-left: 1rem
    }

    .el-upload-list--picture-card .el-upload-list__item-actions .el-upload-list__item-delete {
      position: static;
      font-size: inherit;
      color: inherit
    }

    .el-upload-list--picture-card .el-upload-list__item-actions:hover {
      opacity: 1
    }

    .el-upload-list--picture-card .el-upload-list__item-actions:hover span {
      display: inline-flex
    }

    .el-upload-list--picture-card .el-progress {
      top: 50%;
      left: 50%;
      transform: translate(-50%, -50%);
      bottom: auto;
      width: 126px
    }

    .el-upload-list--picture-card .el-progress .el-progress__text {
      top: 50%
    }

    .el-upload-list--picture .el-upload-list__item {
      overflow: hidden;
      z-index: 0;
      background-color: var(--el-fill-color-blank);
      border: 1px solid var(--el-border-color);
      border-radius: 6px;
      box-sizing: border-box;
      margin-top: 10px;
      padding: 10px;
      display: flex;
      align-items: center
    }

    .el-upload-list--picture .el-upload-list__item .el-icon--check,
    .el-upload-list--picture .el-upload-list__item .el-icon--circle-check {
      color: #fff
    }

    .el-upload-list--picture .el-upload-list__item:hover .el-upload-list__item-status-label {
      opacity: 0;
      display: inline-flex
    }

    .el-upload-list--picture .el-upload-list__item:hover .el-progress__text {
      display: block
    }

    .el-upload-list--picture .el-upload-list__item.is-success .el-upload-list__item-name i {
      display: none
    }

    .el-upload-list--picture .el-upload-list__item .el-icon--close {
      top: 5px;
      transform: translateY(0)
    }

    .el-upload-list--picture .el-upload-list__item-thumbnail {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      width: 70px;
      height: 70px;
      -o-object-fit: contain;
      object-fit: contain;
      position: relative;
      z-index: 1;
      background-color: var(--el-color-white)
    }

    .el-upload-list--picture .el-upload-list__item-status-label {
      position: absolute;
      right: -17px;
      top: -7px;
      width: 46px;
      height: 26px;
      background: var(--el-color-success);
      text-align: center;
      transform: rotate(45deg)
    }

    .el-upload-list--picture .el-upload-list__item-status-label i {
      font-size: 12px;
      margin-top: 12px;
      transform: rotate(-45deg)
    }

    .el-upload-list--picture .el-progress {
      position: relative;
      top: -7px
    }

    .el-upload-cover {
      position: absolute;
      left: 0;
      top: 0;
      width: 100%;
      height: 100%;
      overflow: hidden;
      z-index: 10;
      cursor: default
    }

    .el-upload-cover::after {
      display: inline-block;
      content: """";
      height: 100%;
      vertical-align: middle
    }

    .el-upload-cover img {
      display: block;
      width: 100%;
      height: 100%
    }

    .el-upload-cover__label {
      right: -15px;
      top: -6px;
      width: 40px;
      height: 24px;
      background: var(--el-color-success);
      text-align: center;
      transform: rotate(45deg)
    }

    .el-upload-cover__label i {
      font-size: 12px;
      margin-top: 11px;
      transform: rotate(-45deg);
      color: #fff
    }

    .el-upload-cover__progress {
      display: inline-block;
      vertical-align: middle;
      position: static;
      width: 243px
    }

    .el-upload-cover__progress+.el-upload__inner {
      opacity: 0
    }

    .el-upload-cover__content {
      position: absolute;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%
    }

    .el-upload-cover__interact {
      position: absolute;
      bottom: 0;
      left: 0;
      width: 100%;
      height: 100%;
      background-color: var(--el-overlay-color-light);
      text-align: center
    }

    .el-upload-cover__interact .btn {
      display: inline-block;
      color: #fff;
      font-size: 14px;
      cursor: pointer;
      vertical-align: middle;
      transition: var(--el-transition-md-fade);
      margin-top: 60px
    }

    .el-upload-cover__interact .btn i {
      margin-top: 0
    }

    .el-upload-cover__interact .btn span {
      opacity: 0;
      transition: opacity .15s linear
    }

    .el-upload-cover__interact .btn:not(:first-child) {
      margin-left: 35px
    }

    .el-upload-cover__interact .btn:hover {
      transform: translateY(-13px)
    }

    .el-upload-cover__interact .btn:hover span {
      opacity: 1
    }

    .el-upload-cover__interact .btn i {
      color: #fff;
      display: block;
      font-size: 24px;
      line-height: inherit;
      margin: 0 auto 5px
    }

    .el-upload-cover__title {
      position: absolute;
      bottom: 0;
      left: 0;
      background-color: #fff;
      height: 36px;
      width: 100%;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap;
      font-weight: 400;
      text-align: left;
      padding: 0 10px;
      margin: 0;
      line-height: 36px;
      font-size: 14px;
      color: var(--el-text-color-primary)
    }

    .el-upload-cover+.el-upload__inner {
      opacity: 0;
      position: relative;
      z-index: 1
    }

    .el-vl__wrapper {
      position: relative
    }

    .el-vl__wrapper:hover .el-virtual-scrollbar {
      opacity: 1
    }

    .el-vl__wrapper.always-on .el-virtual-scrollbar {
      opacity: 1
    }

    .el-vl__window {
      scrollbar-width: none
    }

    .el-vl__window::-webkit-scrollbar {
      display: none
    }

    .el-virtual-scrollbar {
      opacity: 0;
      transition: opacity 340ms ease-out
    }

    .el-virtual-scrollbar.always-on {
      opacity: 1
    }

    .el-vg__wrapper {
      position: relative
    }

    .el-popper {
      --el-popper-border-radius: var(--el-popover-border-radius, 4px)
    }

    .el-popper {
      position: absolute;
      border-radius: var(--el-popper-border-radius);
      padding: 5px 11px;
      z-index: 2000;
      font-size: 12px;
      line-height: 20px;
      min-width: 10px;
      overflow-wrap: break-word;
      visibility: visible
    }

    .el-popper.is-dark {
      color: var(--el-bg-color);
      background: var(--el-text-color-primary);
      border: 1px solid var(--el-text-color-primary)
    }

    .el-popper.is-dark .el-popper__arrow::before {
      border: 1px solid var(--el-text-color-primary);
      background: var(--el-text-color-primary);
      right: 0
    }

    .el-popper.is-light {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-border-color-light)
    }

    .el-popper.is-light .el-popper__arrow::before {
      border: 1px solid var(--el-border-color-light);
      background: var(--el-bg-color-overlay);
      right: 0
    }

    .el-popper.is-pure {
      padding: 0
    }

    .el-popper__arrow {
      position: absolute;
      width: 10px;
      height: 10px;
      z-index: -1
    }

    .el-popper__arrow::before {
      position: absolute;
      width: 10px;
      height: 10px;
      z-index: -1;
      content: "" "";
      transform: rotate(45deg);
      background: var(--el-text-color-primary);
      box-sizing: border-box
    }

    .el-popper[data-popper-placement^=top]>.el-popper__arrow {
      bottom: -5px
    }

    .el-popper[data-popper-placement^=top]>.el-popper__arrow::before {
      border-bottom-right-radius: 2px
    }

    .el-popper[data-popper-placement^=bottom]>.el-popper__arrow {
      top: -5px
    }

    .el-popper[data-popper-placement^=bottom]>.el-popper__arrow::before {
      border-top-left-radius: 2px
    }

    .el-popper[data-popper-placement^=left]>.el-popper__arrow {
      right: -5px
    }

    .el-popper[data-popper-placement^=left]>.el-popper__arrow::before {
      border-top-right-radius: 2px
    }

    .el-popper[data-popper-placement^=right]>.el-popper__arrow {
      left: -5px
    }

    .el-popper[data-popper-placement^=right]>.el-popper__arrow::before {
      border-bottom-left-radius: 2px
    }

    .el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent !important;
      border-left-color: transparent !important
    }

    .el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent !important;
      border-right-color: transparent !important
    }

    .el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent !important;
      border-bottom-color: transparent !important
    }

    .el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent !important;
      border-top-color: transparent !important
    }

    .el-statistic {
      --el-statistic-title-font-weight: 400;
      --el-statistic-title-font-size: var(--el-font-size-extra-small);
      --el-statistic-title-color: var(--el-text-color-regular);
      --el-statistic-content-font-weight: 400;
      --el-statistic-content-font-size: var(--el-font-size-extra-large);
      --el-statistic-content-color: var(--el-text-color-primary)
    }

    .el-statistic__head {
      font-weight: var(--el-statistic-title-font-weight);
      font-size: var(--el-statistic-title-font-size);
      color: var(--el-statistic-title-color);
      line-height: 20px;
      margin-bottom: 4px
    }

    .el-statistic__content {
      font-weight: var(--el-statistic-content-font-weight);
      font-size: var(--el-statistic-content-font-size);
      color: var(--el-statistic-content-color)
    }

    .el-statistic__value {
      display: inline-block
    }

    .el-statistic__prefix {
      margin-right: 4px;
      display: inline-block
    }

    .el-statistic__suffix {
      margin-left: 4px;
      display: inline-block
    }

    .el-tour {
      --el-tour-width: 520px;
      --el-tour-padding-primary: 12px;
      --el-tour-font-line-height: var(--el-font-line-height-primary);
      --el-tour-title-font-size: 16px;
      --el-tour-title-text-color: var(--el-text-color-primary);
      --el-tour-title-font-weight: 400;
      --el-tour-close-color: var(--el-color-info);
      --el-tour-font-size: 14px;
      --el-tour-color: var(--el-text-color-primary);
      --el-tour-bg-color: var(--el-bg-color);
      --el-tour-border-radius: 4px
    }

    .el-tour__hollow {
      transition: all var(--el-transition-duration) ease
    }

    .el-tour__content {
      border-radius: var(--el-tour-border-radius);
      width: var(--el-tour-width);
      padding: var(--el-tour-padding-primary);
      background: var(--el-tour-bg-color);
      box-shadow: var(--el-box-shadow-light);
      box-sizing: border-box;
      overflow-wrap: break-word
    }

    .el-tour__arrow {
      position: absolute;
      background: var(--el-tour-bg-color);
      width: 10px;
      height: 10px;
      pointer-events: none;
      transform: rotate(45deg);
      box-sizing: border-box
    }

    .el-tour__content[data-side^=top] .el-tour__arrow {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-tour__content[data-side^=bottom] .el-tour__arrow {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-tour__content[data-side^=left] .el-tour__arrow {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-tour__content[data-side^=right] .el-tour__arrow {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-tour__content[data-side^=top] .el-tour__arrow {
      bottom: -5px
    }

    .el-tour__content[data-side^=bottom] .el-tour__arrow {
      top: -5px
    }

    .el-tour__content[data-side^=left] .el-tour__arrow {
      right: -5px
    }

    .el-tour__content[data-side^=right] .el-tour__arrow {
      left: -5px
    }

    .el-tour__closebtn {
      position: absolute;
      top: 0;
      right: 0;
      padding: 0;
      width: 40px;
      height: 40px;
      background: 0 0;
      border: none;
      outline: 0;
      cursor: pointer;
      font-size: var(--el-message-close-size, 16px)
    }

    .el-tour__closebtn .el-tour__close {
      color: var(--el-tour-close-color);
      font-size: inherit
    }

    .el-tour__closebtn:focus .el-tour__close,
    .el-tour__closebtn:hover .el-tour__close {
      color: var(--el-color-primary)
    }

    .el-tour__header {
      padding-bottom: var(--el-tour-padding-primary)
    }

    .el-tour__header.show-close {
      padding-right: calc(var(--el-tour-padding-primary) + var(--el-message-close-size, 16px))
    }

    .el-tour__title {
      line-height: var(--el-tour-font-line-height);
      font-size: var(--el-tour-title-font-size);
      color: var(--el-tour-title-text-color);
      font-weight: var(--el-tour-title-font-weight)
    }

    .el-tour__body {
      color: var(--el-tour-text-color);
      font-size: var(--el-tour-font-size)
    }

    .el-tour__body img,
    .el-tour__body video {
      max-width: 100%
    }

    .el-tour__footer {
      padding-top: var(--el-tour-padding-primary);
      box-sizing: border-box;
      display: flex;
      justify-content: space-between
    }

    .el-tour__content .el-tour-indicators {
      display: inline-block;
      flex: 1
    }

    .el-tour__content .el-tour-indicator {
      width: 6px;
      height: 6px;
      display: inline-block;
      border-radius: 50%;
      background: var(--el-color-info-light-9);
      margin-right: 6px
    }

    .el-tour__content .el-tour-indicator.is-active {
      background: var(--el-color-primary)
    }

    .el-tour.el-tour--primary {
      --el-tour-title-text-color: #fff;
      --el-tour-text-color: #fff;
      --el-tour-bg-color: var(--el-color-primary);
      --el-tour-close-color: #fff
    }

    .el-tour.el-tour--primary .el-tour__closebtn:focus .el-tour__close,
    .el-tour.el-tour--primary .el-tour__closebtn:hover .el-tour__close {
      color: var(--el-tour-title-text-color)
    }

    .el-tour.el-tour--primary .el-button--default {
      color: var(--el-color-primary);
      border-color: var(--el-color-primary);
      background: #fff
    }

    .el-tour.el-tour--primary .el-button--primary {
      border-color: #fff
    }

    .el-tour.el-tour--primary .el-tour-indicator {
      background: rgba(255, 255, 255, .15)
    }

    .el-tour.el-tour--primary .el-tour-indicator.is-active {
      background: #fff
    }

    .el-tour-parent--hidden {
      overflow: hidden
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/base.css"">
    @charset ""UTF-8"";

    :root {
      --el-color-white: #ffffff;
      --el-color-black: #000000;
      --el-color-primary-rgb: 64, 158, 255;
      --el-color-success-rgb: 103, 194, 58;
      --el-color-warning-rgb: 230, 162, 60;
      --el-color-danger-rgb: 245, 108, 108;
      --el-color-error-rgb: 245, 108, 108;
      --el-color-info-rgb: 144, 147, 153;
      --el-font-size-extra-large: 20px;
      --el-font-size-large: 18px;
      --el-font-size-medium: 16px;
      --el-font-size-base: 14px;
      --el-font-size-small: 13px;
      --el-font-size-extra-small: 12px;
      --el-font-family: 'Helvetica Neue', Helvetica, 'PingFang SC', 'Hiragino Sans GB', 'Microsoft YaHei', '微软雅黑', Arial, sans-serif;
      --el-font-weight-primary: 500;
      --el-font-line-height-primary: 24px;
      --el-index-normal: 1;
      --el-index-top: 1000;
      --el-index-popper: 2000;
      --el-border-radius-base: 4px;
      --el-border-radius-small: 2px;
      --el-border-radius-round: 20px;
      --el-border-radius-circle: 100%;
      --el-transition-duration: 0.3s;
      --el-transition-duration-fast: 0.2s;
      --el-transition-function-ease-in-out-bezier: cubic-bezier(0.645, 0.045, 0.355, 1);
      --el-transition-function-fast-bezier: cubic-bezier(0.23, 1, 0.32, 1);
      --el-transition-all: all var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-fade: opacity var(--el-transition-duration) var(--el-transition-function-fast-bezier);
      --el-transition-md-fade: transform var(--el-transition-duration) var(--el-transition-function-fast-bezier), opacity var(--el-transition-duration) var(--el-transition-function-fast-bezier);
      --el-transition-fade-linear: opacity var(--el-transition-duration-fast) linear;
      --el-transition-border: border-color var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-box-shadow: box-shadow var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-color: color var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-component-size-large: 40px;
      --el-component-size: 32px;
      --el-component-size-small: 24px
    }

    :root {
      color-scheme: light;
      --el-color-white: #ffffff;
      --el-color-black: #000000;
      --el-color-primary: #409eff;
      --el-color-primary-light-3: #79bbff;
      --el-color-primary-light-5: #a0cfff;
      --el-color-primary-light-7: #c6e2ff;
      --el-color-primary-light-8: #d9ecff;
      --el-color-primary-light-9: #ecf5ff;
      --el-color-primary-dark-2: #337ecc;
      --el-color-success: #67c23a;
      --el-color-success-light-3: #95d475;
      --el-color-success-light-5: #b3e19d;
      --el-color-success-light-7: #d1edc4;
      --el-color-success-light-8: #e1f3d8;
      --el-color-success-light-9: #f0f9eb;
      --el-color-success-dark-2: #529b2e;
      --el-color-warning: #e6a23c;
      --el-color-warning-light-3: #eebe77;
      --el-color-warning-light-5: #f3d19e;
      --el-color-warning-light-7: #f8e3c5;
      --el-color-warning-light-8: #faecd8;
      --el-color-warning-light-9: #fdf6ec;
      --el-color-warning-dark-2: #b88230;
      --el-color-danger: #f56c6c;
      --el-color-danger-light-3: #f89898;
      --el-color-danger-light-5: #fab6b6;
      --el-color-danger-light-7: #fcd3d3;
      --el-color-danger-light-8: #fde2e2;
      --el-color-danger-light-9: #fef0f0;
      --el-color-danger-dark-2: #c45656;
      --el-color-error: #f56c6c;
      --el-color-error-light-3: #f89898;
      --el-color-error-light-5: #fab6b6;
      --el-color-error-light-7: #fcd3d3;
      --el-color-error-light-8: #fde2e2;
      --el-color-error-light-9: #fef0f0;
      --el-color-error-dark-2: #c45656;
      --el-color-info: #909399;
      --el-color-info-light-3: #b1b3b8;
      --el-color-info-light-5: #c8c9cc;
      --el-color-info-light-7: #dedfe0;
      --el-color-info-light-8: #e9e9eb;
      --el-color-info-light-9: #f4f4f5;
      --el-color-info-dark-2: #73767a;
      --el-bg-color: #ffffff;
      --el-bg-color-page: #f2f3f5;
      --el-bg-color-overlay: #ffffff;
      --el-text-color-primary: #303133;
      --el-text-color-regular: #606266;
      --el-text-color-secondary: #909399;
      --el-text-color-placeholder: #a8abb2;
      --el-text-color-disabled: #c0c4cc;
      --el-border-color: #dcdfe6;
      --el-border-color-light: #e4e7ed;
      --el-border-color-lighter: #ebeef5;
      --el-border-color-extra-light: #f2f6fc;
      --el-border-color-dark: #d4d7de;
      --el-border-color-darker: #cdd0d6;
      --el-fill-color: #f0f2f5;
      --el-fill-color-light: #f5f7fa;
      --el-fill-color-lighter: #fafafa;
      --el-fill-color-extra-light: #fafcff;
      --el-fill-color-dark: #ebedf0;
      --el-fill-color-darker: #e6e8eb;
      --el-fill-color-blank: #ffffff;
      --el-box-shadow: 0px 12px 32px 4px rgba(0, 0, 0, 0.04), 0px 8px 20px rgba(0, 0, 0, 0.08);
      --el-box-shadow-light: 0px 0px 12px rgba(0, 0, 0, 0.12);
      --el-box-shadow-lighter: 0px 0px 6px rgba(0, 0, 0, 0.12);
      --el-box-shadow-dark: 0px 16px 48px 16px rgba(0, 0, 0, 0.08), 0px 12px 32px rgba(0, 0, 0, 0.12), 0px 8px 16px -8px rgba(0, 0, 0, 0.16);
      --el-disabled-bg-color: var(--el-fill-color-light);
      --el-disabled-text-color: var(--el-text-color-placeholder);
      --el-disabled-border-color: var(--el-border-color-light);
      --el-overlay-color: rgba(0, 0, 0, 0.8);
      --el-overlay-color-light: rgba(0, 0, 0, 0.7);
      --el-overlay-color-lighter: rgba(0, 0, 0, 0.5);
      --el-mask-color: rgba(255, 255, 255, 0.9);
      --el-mask-color-extra-light: rgba(255, 255, 255, 0.3);
      --el-border-width: 1px;
      --el-border-style: solid;
      --el-border-color-hover: var(--el-text-color-disabled);
      --el-border: var(--el-border-width) var(--el-border-style) var(--el-border-color);
      --el-svg-monochrome-grey: var(--el-border-color)
    }

    .fade-in-linear-enter-active,
    .fade-in-linear-leave-active {
      transition: var(--el-transition-fade-linear)
    }

    .fade-in-linear-enter-from,
    .fade-in-linear-leave-to {
      opacity: 0
    }

    .el-fade-in-linear-enter-active,
    .el-fade-in-linear-leave-active {
      transition: var(--el-transition-fade-linear)
    }

    .el-fade-in-linear-enter-from,
    .el-fade-in-linear-leave-to {
      opacity: 0
    }

    .el-fade-in-enter-active,
    .el-fade-in-leave-active {
      transition: all var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-fade-in-enter-from,
    .el-fade-in-leave-active {
      opacity: 0
    }

    .el-zoom-in-center-enter-active,
    .el-zoom-in-center-leave-active {
      transition: all var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-zoom-in-center-enter-from,
    .el-zoom-in-center-leave-active {
      opacity: 0;
      transform: scaleX(0)
    }

    .el-zoom-in-top-enter-active,
    .el-zoom-in-top-leave-active {
      opacity: 1;
      transform: scaleY(1);
      transition: var(--el-transition-md-fade);
      transform-origin: center top
    }

    .el-zoom-in-top-enter-active[data-popper-placement^=top],
    .el-zoom-in-top-leave-active[data-popper-placement^=top] {
      transform-origin: center bottom
    }

    .el-zoom-in-top-enter-from,
    .el-zoom-in-top-leave-active {
      opacity: 0;
      transform: scaleY(0)
    }

    .el-zoom-in-bottom-enter-active,
    .el-zoom-in-bottom-leave-active {
      opacity: 1;
      transform: scaleY(1);
      transition: var(--el-transition-md-fade);
      transform-origin: center bottom
    }

    .el-zoom-in-bottom-enter-from,
    .el-zoom-in-bottom-leave-active {
      opacity: 0;
      transform: scaleY(0)
    }

    .el-zoom-in-left-enter-active,
    .el-zoom-in-left-leave-active {
      opacity: 1;
      transform: scale(1, 1);
      transition: var(--el-transition-md-fade);
      transform-origin: top left
    }

    .el-zoom-in-left-enter-from,
    .el-zoom-in-left-leave-active {
      opacity: 0;
      transform: scale(.45, .45)
    }

    .collapse-transition {
      transition: var(--el-transition-duration) height ease-in-out, var(--el-transition-duration) padding-top ease-in-out, var(--el-transition-duration) padding-bottom ease-in-out
    }

    .el-collapse-transition-enter-active,
    .el-collapse-transition-leave-active {
      transition: var(--el-transition-duration) max-height ease-in-out, var(--el-transition-duration) padding-top ease-in-out, var(--el-transition-duration) padding-bottom ease-in-out
    }

    .horizontal-collapse-transition {
      transition: var(--el-transition-duration) width ease-in-out, var(--el-transition-duration) padding-left ease-in-out, var(--el-transition-duration) padding-right ease-in-out
    }

    .el-list-enter-active,
    .el-list-leave-active {
      transition: all 1s
    }

    .el-list-enter-from,
    .el-list-leave-to {
      opacity: 0;
      transform: translateY(-30px)
    }

    .el-list-leave-active {
      position: absolute !important
    }

    .el-opacity-transition {
      transition: opacity var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-icon-loading {
      -webkit-animation: rotating 2s linear infinite;
      animation: rotating 2s linear infinite
    }

    .el-icon--right {
      margin-left: 5px
    }

    .el-icon--left {
      margin-right: 5px
    }

    @-webkit-keyframes rotating {
      0% {
        transform: rotateZ(0)
      }

      100% {
        transform: rotateZ(360deg)
      }
    }

    @keyframes rotating {
      0% {
        transform: rotateZ(0)
      }

      100% {
        transform: rotateZ(360deg)
      }
    }

    .el-icon {
      --color: inherit;
      height: 1em;
      width: 1em;
      line-height: 1em;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      position: relative;
      fill: currentColor;
      color: var(--color);
      font-size: inherit
    }

    .el-icon.is-loading {
      -webkit-animation: rotating 2s linear infinite;
      animation: rotating 2s linear infinite
    }

    .el-icon svg {
      height: 1em;
      width: 1em
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-row.css"">
    .el-row {
      display: flex;
      flex-wrap: wrap;
      position: relative;
      box-sizing: border-box
    }

    .el-row.is-justify-center {
      justify-content: center
    }

    .el-row.is-justify-end {
      justify-content: flex-end
    }

    .el-row.is-justify-space-between {
      justify-content: space-between
    }

    .el-row.is-justify-space-around {
      justify-content: space-around
    }

    .el-row.is-justify-space-evenly {
      justify-content: space-evenly
    }

    .el-row.is-align-top {
      align-items: flex-start
    }

    .el-row.is-align-middle {
      align-items: center
    }

    .el-row.is-align-bottom {
      align-items: flex-end
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-form.css"">
    .el-form {
      --el-form-label-font-size: var(--el-font-size-base);
      --el-form-inline-content-width: 220px
    }

    .el-form--label-left .el-form-item__label {
      justify-content: flex-start
    }

    .el-form--label-top .el-form-item {
      display: block
    }

    .el-form--label-top .el-form-item .el-form-item__label {
      display: block;
      height: auto;
      text-align: left;
      margin-bottom: 8px;
      line-height: 22px
    }

    .el-form--inline .el-form-item {
      display: inline-flex;
      vertical-align: middle;
      margin-right: 32px
    }

    .el-form--inline.el-form--label-top {
      display: flex;
      flex-wrap: wrap
    }

    .el-form--inline.el-form--label-top .el-form-item {
      display: block
    }

    .el-form--large.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 12px;
      line-height: 22px
    }

    .el-form--default.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 8px;
      line-height: 22px
    }

    .el-form--small.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 4px;
      line-height: 20px
    }

    .el-form-item {
      display: flex;
      --font-size: 14px;
      margin-bottom: 18px
    }

    .el-form-item .el-form-item {
      margin-bottom: 0
    }

    .el-form-item .el-input__validateIcon {
      display: none
    }

    .el-form-item--large {
      --font-size: 14px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 22px
    }

    .el-form-item--large .el-form-item__label {
      height: 40px;
      line-height: 40px
    }

    .el-form-item--large .el-form-item__content {
      line-height: 40px
    }

    .el-form-item--large .el-form-item__error {
      padding-top: 4px
    }

    .el-form-item--default {
      --font-size: 14px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 18px
    }

    .el-form-item--default .el-form-item__label {
      height: 32px;
      line-height: 32px
    }

    .el-form-item--default .el-form-item__content {
      line-height: 32px
    }

    .el-form-item--default .el-form-item__error {
      padding-top: 2px
    }

    .el-form-item--small {
      --font-size: 12px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 18px
    }

    .el-form-item--small .el-form-item__label {
      height: 24px;
      line-height: 24px
    }

    .el-form-item--small .el-form-item__content {
      line-height: 24px
    }

    .el-form-item--small .el-form-item__error {
      padding-top: 2px
    }

    .el-form-item__label-wrap {
      display: flex
    }

    .el-form-item__label {
      display: inline-flex;
      justify-content: flex-end;
      align-items: flex-start;
      flex: 0 0 auto;
      font-size: var(--el-form-label-font-size);
      color: var(--el-text-color-regular);
      height: 32px;
      line-height: 32px;
      padding: 0 12px 0 0;
      box-sizing: border-box
    }

    .el-form-item__content {
      display: flex;
      flex-wrap: wrap;
      align-items: center;
      flex: 1;
      line-height: 32px;
      position: relative;
      font-size: var(--font-size);
      min-width: 0
    }

    .el-form-item__content .el-input-group {
      vertical-align: top
    }

    .el-form-item__error {
      color: var(--el-color-danger);
      font-size: 12px;
      line-height: 1;
      padding-top: 2px;
      position: absolute;
      top: 100%;
      left: 0
    }

    .el-form-item__error--inline {
      position: relative;
      top: auto;
      left: auto;
      display: inline-block;
      margin-left: 10px
    }

    .el-form-item.is-required:not(.is-no-asterisk).asterisk-left>.el-form-item__label-wrap>.el-form-item__label:before,
    .el-form-item.is-required:not(.is-no-asterisk).asterisk-left>.el-form-item__label:before {
      content: ""*"";
      color: var(--el-color-danger);
      margin-right: 4px
    }

    .el-form-item.is-required:not(.is-no-asterisk).asterisk-right>.el-form-item__label-wrap>.el-form-item__label:after,
    .el-form-item.is-required:not(.is-no-asterisk).asterisk-right>.el-form-item__label:after {
      content: ""*"";
      color: var(--el-color-danger);
      margin-left: 4px
    }

    .el-form-item.is-error .el-input__wrapper,
    .el-form-item.is-error .el-input__wrapper.is-focus,
    .el-form-item.is-error .el-input__wrapper:focus,
    .el-form-item.is-error .el-input__wrapper:hover,
    .el-form-item.is-error .el-select__wrapper,
    .el-form-item.is-error .el-select__wrapper.is-focus,
    .el-form-item.is-error .el-select__wrapper:focus,
    .el-form-item.is-error .el-select__wrapper:hover,
    .el-form-item.is-error .el-textarea__inner,
    .el-form-item.is-error .el-textarea__inner.is-focus,
    .el-form-item.is-error .el-textarea__inner:focus,
    .el-form-item.is-error .el-textarea__inner:hover {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-form-item.is-error .el-input-group__append .el-input__wrapper,
    .el-form-item.is-error .el-input-group__prepend .el-input__wrapper {
      box-shadow: 0 0 0 1px transparent inset
    }

    .el-form-item.is-error .el-input__validateIcon {
      color: var(--el-color-danger)
    }

    .el-form-item--feedback .el-input__validateIcon {
      display: inline-flex
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-button.css"">
    .el-button {
      --el-button-font-weight: var(--el-font-weight-primary);
      --el-button-border-color: var(--el-border-color);
      --el-button-bg-color: var(--el-fill-color-blank);
      --el-button-text-color: var(--el-text-color-regular);
      --el-button-disabled-text-color: var(--el-disabled-text-color);
      --el-button-disabled-bg-color: var(--el-fill-color-blank);
      --el-button-disabled-border-color: var(--el-border-color-light);
      --el-button-divide-border-color: rgba(255, 255, 255, 0.5);
      --el-button-hover-text-color: var(--el-color-primary);
      --el-button-hover-bg-color: var(--el-color-primary-light-9);
      --el-button-hover-border-color: var(--el-color-primary-light-7);
      --el-button-active-text-color: var(--el-button-hover-text-color);
      --el-button-active-border-color: var(--el-color-primary);
      --el-button-active-bg-color: var(--el-button-hover-bg-color);
      --el-button-outline-color: var(--el-color-primary-light-5);
      --el-button-hover-link-text-color: var(--el-color-info);
      --el-button-active-color: var(--el-text-color-primary)
    }

    .el-button {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      line-height: 1;
      height: 32px;
      white-space: nowrap;
      cursor: pointer;
      color: var(--el-button-text-color);
      text-align: center;
      box-sizing: border-box;
      outline: 0;
      transition: .1s;
      font-weight: var(--el-button-font-weight);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      vertical-align: middle;
      -webkit-appearance: none;
      background-color: var(--el-button-bg-color);
      border: var(--el-border);
      border-color: var(--el-button-border-color);
      padding: 8px 15px;
      font-size: var(--el-font-size-base);
      border-radius: var(--el-border-radius-base)
    }

    .el-button:focus,
    .el-button:hover {
      color: var(--el-button-hover-text-color);
      border-color: var(--el-button-hover-border-color);
      background-color: var(--el-button-hover-bg-color);
      outline: 0
    }

    .el-button:active {
      color: var(--el-button-active-text-color);
      border-color: var(--el-button-active-border-color);
      background-color: var(--el-button-active-bg-color);
      outline: 0
    }

    .el-button:focus-visible {
      outline: 2px solid var(--el-button-outline-color);
      outline-offset: 1px
    }

    .el-button>span {
      display: inline-flex;
      align-items: center
    }

    .el-button+.el-button {
      margin-left: 12px
    }

    .el-button.is-round {
      padding: 8px 15px
    }

    .el-button::-moz-focus-inner {
      border: 0
    }

    .el-button [class*=el-icon]+span {
      margin-left: 6px
    }

    .el-button [class*=el-icon] svg {
      vertical-align: bottom
    }

    .el-button.is-plain {
      --el-button-hover-text-color: var(--el-color-primary);
      --el-button-hover-bg-color: var(--el-fill-color-blank);
      --el-button-hover-border-color: var(--el-color-primary)
    }

    .el-button.is-active {
      color: var(--el-button-active-text-color);
      border-color: var(--el-button-active-border-color);
      background-color: var(--el-button-active-bg-color);
      outline: 0
    }

    .el-button.is-disabled,
    .el-button.is-disabled:focus,
    .el-button.is-disabled:hover {
      color: var(--el-button-disabled-text-color);
      cursor: not-allowed;
      background-image: none;
      background-color: var(--el-button-disabled-bg-color);
      border-color: var(--el-button-disabled-border-color)
    }

    .el-button.is-loading {
      position: relative;
      pointer-events: none
    }

    .el-button.is-loading:before {
      z-index: 1;
      pointer-events: none;
      content: """";
      position: absolute;
      left: -1px;
      top: -1px;
      right: -1px;
      bottom: -1px;
      border-radius: inherit;
      background-color: var(--el-mask-color-extra-light)
    }

    .el-button.is-round {
      border-radius: var(--el-border-radius-round)
    }

    .el-button.is-circle {
      width: 32px;
      border-radius: 50%;
      padding: 8px
    }

    .el-button.is-text {
      color: var(--el-button-text-color);
      border: 0 solid transparent;
      background-color: transparent
    }

    .el-button.is-text.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important
    }

    .el-button.is-text:not(.is-disabled):focus,
    .el-button.is-text:not(.is-disabled):hover {
      background-color: var(--el-fill-color-light)
    }

    .el-button.is-text:not(.is-disabled):focus-visible {
      outline: 2px solid var(--el-button-outline-color);
      outline-offset: 1px
    }

    .el-button.is-text:not(.is-disabled):active {
      background-color: var(--el-fill-color)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg {
      background-color: var(--el-fill-color-light)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg:focus,
    .el-button.is-text:not(.is-disabled).is-has-bg:hover {
      background-color: var(--el-fill-color)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg:active {
      background-color: var(--el-fill-color-dark)
    }

    .el-button__text--expand {
      letter-spacing: .3em;
      margin-right: -.3em
    }

    .el-button.is-link {
      border-color: transparent;
      color: var(--el-button-text-color);
      background: 0 0;
      padding: 2px;
      height: auto
    }

    .el-button.is-link:focus,
    .el-button.is-link:hover {
      color: var(--el-button-hover-link-text-color)
    }

    .el-button.is-link.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important;
      border-color: transparent !important
    }

    .el-button.is-link:not(.is-disabled):focus,
    .el-button.is-link:not(.is-disabled):hover {
      border-color: transparent;
      background-color: transparent
    }

    .el-button.is-link:not(.is-disabled):active {
      color: var(--el-button-active-color);
      border-color: transparent;
      background-color: transparent
    }

    .el-button--text {
      border-color: transparent;
      background: 0 0;
      color: var(--el-color-primary);
      padding-left: 0;
      padding-right: 0
    }

    .el-button--text.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important;
      border-color: transparent !important
    }

    .el-button--text:not(.is-disabled):focus,
    .el-button--text:not(.is-disabled):hover {
      color: var(--el-color-primary-light-3);
      border-color: transparent;
      background-color: transparent
    }

    .el-button--text:not(.is-disabled):active {
      color: var(--el-color-primary-dark-2);
      border-color: transparent;
      background-color: transparent
    }

    .el-button__link--expand {
      letter-spacing: .3em;
      margin-right: -.3em
    }

    .el-button--primary {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-primary);
      --el-button-border-color: var(--el-color-primary);
      --el-button-outline-color: var(--el-color-primary-light-5);
      --el-button-active-color: var(--el-color-primary-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-primary-light-5);
      --el-button-hover-bg-color: var(--el-color-primary-light-3);
      --el-button-hover-border-color: var(--el-color-primary-light-3);
      --el-button-active-bg-color: var(--el-color-primary-dark-2);
      --el-button-active-border-color: var(--el-color-primary-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-primary-light-5);
      --el-button-disabled-border-color: var(--el-color-primary-light-5)
    }

    .el-button--primary.is-link,
    .el-button--primary.is-plain,
    .el-button--primary.is-text {
      --el-button-text-color: var(--el-color-primary);
      --el-button-bg-color: var(--el-color-primary-light-9);
      --el-button-border-color: var(--el-color-primary-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-primary);
      --el-button-hover-border-color: var(--el-color-primary);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--primary.is-link.is-disabled,
    .el-button--primary.is-link.is-disabled:active,
    .el-button--primary.is-link.is-disabled:focus,
    .el-button--primary.is-link.is-disabled:hover,
    .el-button--primary.is-plain.is-disabled,
    .el-button--primary.is-plain.is-disabled:active,
    .el-button--primary.is-plain.is-disabled:focus,
    .el-button--primary.is-plain.is-disabled:hover,
    .el-button--primary.is-text.is-disabled,
    .el-button--primary.is-text.is-disabled:active,
    .el-button--primary.is-text.is-disabled:focus,
    .el-button--primary.is-text.is-disabled:hover {
      color: var(--el-color-primary-light-5);
      background-color: var(--el-color-primary-light-9);
      border-color: var(--el-color-primary-light-8)
    }

    .el-button--success {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-success);
      --el-button-border-color: var(--el-color-success);
      --el-button-outline-color: var(--el-color-success-light-5);
      --el-button-active-color: var(--el-color-success-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-success-light-5);
      --el-button-hover-bg-color: var(--el-color-success-light-3);
      --el-button-hover-border-color: var(--el-color-success-light-3);
      --el-button-active-bg-color: var(--el-color-success-dark-2);
      --el-button-active-border-color: var(--el-color-success-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-success-light-5);
      --el-button-disabled-border-color: var(--el-color-success-light-5)
    }

    .el-button--success.is-link,
    .el-button--success.is-plain,
    .el-button--success.is-text {
      --el-button-text-color: var(--el-color-success);
      --el-button-bg-color: var(--el-color-success-light-9);
      --el-button-border-color: var(--el-color-success-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-success);
      --el-button-hover-border-color: var(--el-color-success);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--success.is-link.is-disabled,
    .el-button--success.is-link.is-disabled:active,
    .el-button--success.is-link.is-disabled:focus,
    .el-button--success.is-link.is-disabled:hover,
    .el-button--success.is-plain.is-disabled,
    .el-button--success.is-plain.is-disabled:active,
    .el-button--success.is-plain.is-disabled:focus,
    .el-button--success.is-plain.is-disabled:hover,
    .el-button--success.is-text.is-disabled,
    .el-button--success.is-text.is-disabled:active,
    .el-button--success.is-text.is-disabled:focus,
    .el-button--success.is-text.is-disabled:hover {
      color: var(--el-color-success-light-5);
      background-color: var(--el-color-success-light-9);
      border-color: var(--el-color-success-light-8)
    }

    .el-button--warning {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-warning);
      --el-button-border-color: var(--el-color-warning);
      --el-button-outline-color: var(--el-color-warning-light-5);
      --el-button-active-color: var(--el-color-warning-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-warning-light-5);
      --el-button-hover-bg-color: var(--el-color-warning-light-3);
      --el-button-hover-border-color: var(--el-color-warning-light-3);
      --el-button-active-bg-color: var(--el-color-warning-dark-2);
      --el-button-active-border-color: var(--el-color-warning-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-warning-light-5);
      --el-button-disabled-border-color: var(--el-color-warning-light-5)
    }

    .el-button--warning.is-link,
    .el-button--warning.is-plain,
    .el-button--warning.is-text {
      --el-button-text-color: var(--el-color-warning);
      --el-button-bg-color: var(--el-color-warning-light-9);
      --el-button-border-color: var(--el-color-warning-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-warning);
      --el-button-hover-border-color: var(--el-color-warning);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--warning.is-link.is-disabled,
    .el-button--warning.is-link.is-disabled:active,
    .el-button--warning.is-link.is-disabled:focus,
    .el-button--warning.is-link.is-disabled:hover,
    .el-button--warning.is-plain.is-disabled,
    .el-button--warning.is-plain.is-disabled:active,
    .el-button--warning.is-plain.is-disabled:focus,
    .el-button--warning.is-plain.is-disabled:hover,
    .el-button--warning.is-text.is-disabled,
    .el-button--warning.is-text.is-disabled:active,
    .el-button--warning.is-text.is-disabled:focus,
    .el-button--warning.is-text.is-disabled:hover {
      color: var(--el-color-warning-light-5);
      background-color: var(--el-color-warning-light-9);
      border-color: var(--el-color-warning-light-8)
    }

    .el-button--danger {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-danger);
      --el-button-border-color: var(--el-color-danger);
      --el-button-outline-color: var(--el-color-danger-light-5);
      --el-button-active-color: var(--el-color-danger-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-danger-light-5);
      --el-button-hover-bg-color: var(--el-color-danger-light-3);
      --el-button-hover-border-color: var(--el-color-danger-light-3);
      --el-button-active-bg-color: var(--el-color-danger-dark-2);
      --el-button-active-border-color: var(--el-color-danger-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-danger-light-5);
      --el-button-disabled-border-color: var(--el-color-danger-light-5)
    }

    .el-button--danger.is-link,
    .el-button--danger.is-plain,
    .el-button--danger.is-text {
      --el-button-text-color: var(--el-color-danger);
      --el-button-bg-color: var(--el-color-danger-light-9);
      --el-button-border-color: var(--el-color-danger-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-danger);
      --el-button-hover-border-color: var(--el-color-danger);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--danger.is-link.is-disabled,
    .el-button--danger.is-link.is-disabled:active,
    .el-button--danger.is-link.is-disabled:focus,
    .el-button--danger.is-link.is-disabled:hover,
    .el-button--danger.is-plain.is-disabled,
    .el-button--danger.is-plain.is-disabled:active,
    .el-button--danger.is-plain.is-disabled:focus,
    .el-button--danger.is-plain.is-disabled:hover,
    .el-button--danger.is-text.is-disabled,
    .el-button--danger.is-text.is-disabled:active,
    .el-button--danger.is-text.is-disabled:focus,
    .el-button--danger.is-text.is-disabled:hover {
      color: var(--el-color-danger-light-5);
      background-color: var(--el-color-danger-light-9);
      border-color: var(--el-color-danger-light-8)
    }

    .el-button--info {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-info);
      --el-button-border-color: var(--el-color-info);
      --el-button-outline-color: var(--el-color-info-light-5);
      --el-button-active-color: var(--el-color-info-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-info-light-5);
      --el-button-hover-bg-color: var(--el-color-info-light-3);
      --el-button-hover-border-color: var(--el-color-info-light-3);
      --el-button-active-bg-color: var(--el-color-info-dark-2);
      --el-button-active-border-color: var(--el-color-info-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-info-light-5);
      --el-button-disabled-border-color: var(--el-color-info-light-5)
    }

    .el-button--info.is-link,
    .el-button--info.is-plain,
    .el-button--info.is-text {
      --el-button-text-color: var(--el-color-info);
      --el-button-bg-color: var(--el-color-info-light-9);
      --el-button-border-color: var(--el-color-info-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-info);
      --el-button-hover-border-color: var(--el-color-info);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--info.is-link.is-disabled,
    .el-button--info.is-link.is-disabled:active,
    .el-button--info.is-link.is-disabled:focus,
    .el-button--info.is-link.is-disabled:hover,
    .el-button--info.is-plain.is-disabled,
    .el-button--info.is-plain.is-disabled:active,
    .el-button--info.is-plain.is-disabled:focus,
    .el-button--info.is-plain.is-disabled:hover,
    .el-button--info.is-text.is-disabled,
    .el-button--info.is-text.is-disabled:active,
    .el-button--info.is-text.is-disabled:focus,
    .el-button--info.is-text.is-disabled:hover {
      color: var(--el-color-info-light-5);
      background-color: var(--el-color-info-light-9);
      border-color: var(--el-color-info-light-8)
    }

    .el-button--large {
      --el-button-size: 40px;
      height: var(--el-button-size);
      padding: 12px 19px;
      font-size: var(--el-font-size-base);
      border-radius: var(--el-border-radius-base)
    }

    .el-button--large [class*=el-icon]+span {
      margin-left: 8px
    }

    .el-button--large.is-round {
      padding: 12px 19px
    }

    .el-button--large.is-circle {
      width: var(--el-button-size);
      padding: 12px
    }

    .el-button--small {
      --el-button-size: 24px;
      height: var(--el-button-size);
      padding: 5px 11px;
      font-size: 12px;
      border-radius: calc(var(--el-border-radius-base) - 1px)
    }

    .el-button--small [class*=el-icon]+span {
      margin-left: 4px
    }

    .el-button--small.is-round {
      padding: 5px 11px
    }

    .el-button--small.is-circle {
      width: var(--el-button-size);
      padding: 5px
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-form-item.css""></style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-input.css"">
    .el-textarea {
      --el-input-text-color: var(--el-text-color-regular);
      --el-input-border: var(--el-border);
      --el-input-hover-border: var(--el-border-color-hover);
      --el-input-focus-border: var(--el-color-primary);
      --el-input-transparent-border: 0 0 0 1px transparent inset;
      --el-input-border-color: var(--el-border-color);
      --el-input-border-radius: var(--el-border-radius-base);
      --el-input-bg-color: var(--el-fill-color-blank);
      --el-input-icon-color: var(--el-text-color-placeholder);
      --el-input-placeholder-color: var(--el-text-color-placeholder);
      --el-input-hover-border-color: var(--el-border-color-hover);
      --el-input-clear-hover-color: var(--el-text-color-secondary);
      --el-input-focus-border-color: var(--el-color-primary);
      --el-input-width: 100%
    }

    .el-textarea {
      position: relative;
      display: inline-block;
      width: 100%;
      vertical-align: bottom;
      font-size: var(--el-font-size-base)
    }

    .el-textarea__inner {
      position: relative;
      display: block;
      resize: vertical;
      padding: 5px 11px;
      line-height: 1.5;
      box-sizing: border-box;
      width: 100%;
      font-size: inherit;
      font-family: inherit;
      color: var(--el-input-text-color, var(--el-text-color-regular));
      background-color: var(--el-input-bg-color, var(--el-fill-color-blank));
      background-image: none;
      -webkit-appearance: none;
      box-shadow: 0 0 0 1px var(--el-input-border-color, var(--el-border-color)) inset;
      border-radius: var(--el-input-border-radius, var(--el-border-radius-base));
      transition: var(--el-transition-box-shadow);
      border: none
    }

    .el-textarea__inner::-moz-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner:-ms-input-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner::placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner:hover {
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-textarea__inner:focus {
      outline: 0;
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-textarea .el-input__count {
      color: var(--el-color-info);
      background: var(--el-fill-color-blank);
      position: absolute;
      font-size: 12px;
      line-height: 14px;
      bottom: 5px;
      right: 10px
    }

    .el-textarea.is-disabled .el-textarea__inner {
      box-shadow: 0 0 0 1px var(--el-disabled-border-color) inset;
      background-color: var(--el-disabled-bg-color);
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-textarea.is-disabled .el-textarea__inner::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-disabled .el-textarea__inner:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-disabled .el-textarea__inner::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-exceed .el-textarea__inner {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-textarea.is-exceed .el-input__count {
      color: var(--el-color-danger)
    }

    .el-input {
      --el-input-text-color: var(--el-text-color-regular);
      --el-input-border: var(--el-border);
      --el-input-hover-border: var(--el-border-color-hover);
      --el-input-focus-border: var(--el-color-primary);
      --el-input-transparent-border: 0 0 0 1px transparent inset;
      --el-input-border-color: var(--el-border-color);
      --el-input-border-radius: var(--el-border-radius-base);
      --el-input-bg-color: var(--el-fill-color-blank);
      --el-input-icon-color: var(--el-text-color-placeholder);
      --el-input-placeholder-color: var(--el-text-color-placeholder);
      --el-input-hover-border-color: var(--el-border-color-hover);
      --el-input-clear-hover-color: var(--el-text-color-secondary);
      --el-input-focus-border-color: var(--el-color-primary);
      --el-input-width: 100%
    }

    .el-input {
      --el-input-height: var(--el-component-size);
      position: relative;
      font-size: var(--el-font-size-base);
      display: inline-flex;
      width: var(--el-input-width);
      line-height: var(--el-input-height);
      box-sizing: border-box;
      vertical-align: middle
    }

    .el-input::-webkit-scrollbar {
      z-index: 11;
      width: 6px
    }

    .el-input::-webkit-scrollbar:horizontal {
      height: 6px
    }

    .el-input::-webkit-scrollbar-thumb {
      border-radius: 5px;
      width: 6px;
      background: var(--el-text-color-disabled)
    }

    .el-input::-webkit-scrollbar-corner {
      background: var(--el-fill-color-blank)
    }

    .el-input::-webkit-scrollbar-track {
      background: var(--el-fill-color-blank)
    }

    .el-input::-webkit-scrollbar-track-piece {
      background: var(--el-fill-color-blank);
      width: 6px
    }

    .el-input .el-input__clear,
    .el-input .el-input__password {
      color: var(--el-input-icon-color);
      font-size: 14px;
      cursor: pointer
    }

    .el-input .el-input__clear:hover,
    .el-input .el-input__password:hover {
      color: var(--el-input-clear-hover-color)
    }

    .el-input .el-input__count {
      height: 100%;
      display: inline-flex;
      align-items: center;
      color: var(--el-color-info);
      font-size: 12px
    }

    .el-input .el-input__count .el-input__count-inner {
      background: var(--el-fill-color-blank);
      line-height: initial;
      display: inline-block;
      padding-left: 8px
    }

    .el-input__wrapper {
      display: inline-flex;
      flex-grow: 1;
      align-items: center;
      justify-content: center;
      padding: 1px 11px;
      background-color: var(--el-input-bg-color, var(--el-fill-color-blank));
      background-image: none;
      border-radius: var(--el-input-border-radius, var(--el-border-radius-base));
      cursor: text;
      transition: var(--el-transition-box-shadow);
      transform: translate3d(0, 0, 0);
      box-shadow: 0 0 0 1px var(--el-input-border-color, var(--el-border-color)) inset
    }

    .el-input__wrapper:hover {
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-input__wrapper.is-focus {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 32px) - 2px);
      width: 100%;
      flex-grow: 1;
      -webkit-appearance: none;
      color: var(--el-input-text-color, var(--el-text-color-regular));
      font-size: inherit;
      height: var(--el-input-inner-height);
      line-height: var(--el-input-inner-height);
      padding: 0;
      outline: 0;
      border: none;
      background: 0 0;
      box-sizing: border-box
    }

    .el-input__inner:focus {
      outline: 0
    }

    .el-input__inner::-moz-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner:-ms-input-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner::placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner[type=password]::-ms-reveal {
      display: none
    }

    .el-input__inner[type=number] {
      line-height: 1
    }

    .el-input__prefix {
      display: inline-flex;
      white-space: nowrap;
      flex-shrink: 0;
      flex-wrap: nowrap;
      height: 100%;
      text-align: center;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder));
      transition: all var(--el-transition-duration);
      pointer-events: none
    }

    .el-input__prefix-inner {
      pointer-events: all;
      display: inline-flex;
      align-items: center;
      justify-content: center
    }

    .el-input__prefix-inner>:last-child {
      margin-right: 8px
    }

    .el-input__prefix-inner>:first-child,
    .el-input__prefix-inner>:first-child.el-input__icon {
      margin-left: 0
    }

    .el-input__suffix {
      display: inline-flex;
      white-space: nowrap;
      flex-shrink: 0;
      flex-wrap: nowrap;
      height: 100%;
      text-align: center;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder));
      transition: all var(--el-transition-duration);
      pointer-events: none
    }

    .el-input__suffix-inner {
      pointer-events: all;
      display: inline-flex;
      align-items: center;
      justify-content: center
    }

    .el-input__suffix-inner>:first-child {
      margin-left: 8px
    }

    .el-input .el-input__icon {
      height: inherit;
      line-height: inherit;
      display: flex;
      justify-content: center;
      align-items: center;
      transition: all var(--el-transition-duration);
      margin-left: 8px
    }

    .el-input__validateIcon {
      pointer-events: none
    }

    .el-input.is-active .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-input-focus-color, ) inset
    }

    .el-input.is-disabled {
      cursor: not-allowed
    }

    .el-input.is-disabled .el-input__wrapper {
      background-color: var(--el-disabled-bg-color);
      box-shadow: 0 0 0 1px var(--el-disabled-border-color) inset
    }

    .el-input.is-disabled .el-input__inner {
      color: var(--el-disabled-text-color);
      -webkit-text-fill-color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-input.is-disabled .el-input__inner::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__inner:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__inner::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__icon {
      cursor: not-allowed
    }

    .el-input.is-exceed .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-input.is-exceed .el-input__suffix .el-input__count {
      color: var(--el-color-danger)
    }

    .el-input--large {
      --el-input-height: var(--el-component-size-large);
      font-size: 14px
    }

    .el-input--large .el-input__wrapper {
      padding: 1px 15px
    }

    .el-input--large .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 40px) - 2px)
    }

    .el-input--small {
      --el-input-height: var(--el-component-size-small);
      font-size: 12px
    }

    .el-input--small .el-input__wrapper {
      padding: 1px 7px
    }

    .el-input--small .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 24px) - 2px)
    }

    .el-input-group {
      display: inline-flex;
      width: 100%;
      align-items: stretch
    }

    .el-input-group__append,
    .el-input-group__prepend {
      background-color: var(--el-fill-color-light);
      color: var(--el-color-info);
      position: relative;
      display: inline-flex;
      align-items: center;
      justify-content: center;
      min-height: 100%;
      border-radius: var(--el-input-border-radius);
      padding: 0 20px;
      white-space: nowrap
    }

    .el-input-group__append:focus,
    .el-input-group__prepend:focus {
      outline: 0
    }

    .el-input-group__append .el-button,
    .el-input-group__append .el-select,
    .el-input-group__prepend .el-button,
    .el-input-group__prepend .el-select {
      display: inline-block;
      margin: 0 -20px
    }

    .el-input-group__append button.el-button,
    .el-input-group__append button.el-button:hover,
    .el-input-group__append div.el-select .el-select__wrapper,
    .el-input-group__append div.el-select:hover .el-select__wrapper,
    .el-input-group__prepend button.el-button,
    .el-input-group__prepend button.el-button:hover,
    .el-input-group__prepend div.el-select .el-select__wrapper,
    .el-input-group__prepend div.el-select:hover .el-select__wrapper {
      border-color: transparent;
      background-color: transparent;
      color: inherit
    }

    .el-input-group__append .el-button,
    .el-input-group__append .el-input,
    .el-input-group__prepend .el-button,
    .el-input-group__prepend .el-input {
      font-size: inherit
    }

    .el-input-group__prepend {
      border-right: 0;
      border-top-right-radius: 0;
      border-bottom-right-radius: 0;
      box-shadow: 1px 0 0 0 var(--el-input-border-color) inset, 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset
    }

    .el-input-group__append {
      border-left: 0;
      border-top-left-radius: 0;
      border-bottom-left-radius: 0;
      box-shadow: 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset, -1px 0 0 0 var(--el-input-border-color) inset
    }

    .el-input-group--prepend>.el-input__wrapper {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0
    }

    .el-input-group--prepend .el-input-group__prepend .el-select .el-select__wrapper {
      border-top-right-radius: 0;
      border-bottom-right-radius: 0;
      box-shadow: 1px 0 0 0 var(--el-input-border-color) inset, 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset
    }

    .el-input-group--append>.el-input__wrapper {
      border-top-right-radius: 0;
      border-bottom-right-radius: 0
    }

    .el-input-group--append .el-input-group__append .el-select .el-select__wrapper {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0;
      box-shadow: 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset, -1px 0 0 0 var(--el-input-border-color) inset
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-col.css"">
    [class*=el-col-] {
      box-sizing: border-box
    }

    [class*=el-col-].is-guttered {
      display: block;
      min-height: 1px
    }

    .el-col-0 {
      display: none
    }

    .el-col-0.is-guttered {
      display: none
    }

    .el-col-0 {
      max-width: 0%;
      flex: 0 0 0%
    }

    .el-col-offset-0 {
      margin-left: 0
    }

    .el-col-pull-0 {
      position: relative;
      right: 0
    }

    .el-col-push-0 {
      position: relative;
      left: 0
    }

    .el-col-1 {
      max-width: 4.1666666667%;
      flex: 0 0 4.1666666667%
    }

    .el-col-offset-1 {
      margin-left: 4.1666666667%
    }

    .el-col-pull-1 {
      position: relative;
      right: 4.1666666667%
    }

    .el-col-push-1 {
      position: relative;
      left: 4.1666666667%
    }

    .el-col-2 {
      max-width: 8.3333333333%;
      flex: 0 0 8.3333333333%
    }

    .el-col-offset-2 {
      margin-left: 8.3333333333%
    }

    .el-col-pull-2 {
      position: relative;
      right: 8.3333333333%
    }

    .el-col-push-2 {
      position: relative;
      left: 8.3333333333%
    }

    .el-col-3 {
      max-width: 12.5%;
      flex: 0 0 12.5%
    }

    .el-col-offset-3 {
      margin-left: 12.5%
    }

    .el-col-pull-3 {
      position: relative;
      right: 12.5%
    }

    .el-col-push-3 {
      position: relative;
      left: 12.5%
    }

    .el-col-4 {
      max-width: 16.6666666667%;
      flex: 0 0 16.6666666667%
    }

    .el-col-offset-4 {
      margin-left: 16.6666666667%
    }

    .el-col-pull-4 {
      position: relative;
      right: 16.6666666667%
    }

    .el-col-push-4 {
      position: relative;
      left: 16.6666666667%
    }

    .el-col-5 {
      max-width: 20.8333333333%;
      flex: 0 0 20.8333333333%
    }

    .el-col-offset-5 {
      margin-left: 20.8333333333%
    }

    .el-col-pull-5 {
      position: relative;
      right: 20.8333333333%
    }

    .el-col-push-5 {
      position: relative;
      left: 20.8333333333%
    }

    .el-col-6 {
      max-width: 25%;
      flex: 0 0 25%
    }

    .el-col-offset-6 {
      margin-left: 25%
    }

    .el-col-pull-6 {
      position: relative;
      right: 25%
    }

    .el-col-push-6 {
      position: relative;
      left: 25%
    }

    .el-col-7 {
      max-width: 29.1666666667%;
      flex: 0 0 29.1666666667%
    }

    .el-col-offset-7 {
      margin-left: 29.1666666667%
    }

    .el-col-pull-7 {
      position: relative;
      right: 29.1666666667%
    }

    .el-col-push-7 {
      position: relative;
      left: 29.1666666667%
    }

    .el-col-8 {
      max-width: 33.3333333333%;
      flex: 0 0 33.3333333333%
    }

    .el-col-offset-8 {
      margin-left: 33.3333333333%
    }

    .el-col-pull-8 {
      position: relative;
      right: 33.3333333333%
    }

    .el-col-push-8 {
      position: relative;
      left: 33.3333333333%
    }

    .el-col-9 {
      max-width: 37.5%;
      flex: 0 0 37.5%
    }

    .el-col-offset-9 {
      margin-left: 37.5%
    }

    .el-col-pull-9 {
      position: relative;
      right: 37.5%
    }

    .el-col-push-9 {
      position: relative;
      left: 37.5%
    }

    .el-col-10 {
      max-width: 41.6666666667%;
      flex: 0 0 41.6666666667%
    }

    .el-col-offset-10 {
      margin-left: 41.6666666667%
    }

    .el-col-pull-10 {
      position: relative;
      right: 41.6666666667%
    }

    .el-col-push-10 {
      position: relative;
      left: 41.6666666667%
    }

    .el-col-11 {
      max-width: 45.8333333333%;
      flex: 0 0 45.8333333333%
    }

    .el-col-offset-11 {
      margin-left: 45.8333333333%
    }

    .el-col-pull-11 {
      position: relative;
      right: 45.8333333333%
    }

    .el-col-push-11 {
      position: relative;
      left: 45.8333333333%
    }

    .el-col-12 {
      max-width: 50%;
      flex: 0 0 50%
    }

    .el-col-offset-12 {
      margin-left: 50%
    }

    .el-col-pull-12 {
      position: relative;
      right: 50%
    }

    .el-col-push-12 {
      position: relative;
      left: 50%
    }

    .el-col-13 {
      max-width: 54.1666666667%;
      flex: 0 0 54.1666666667%
    }

    .el-col-offset-13 {
      margin-left: 54.1666666667%
    }

    .el-col-pull-13 {
      position: relative;
      right: 54.1666666667%
    }

    .el-col-push-13 {
      position: relative;
      left: 54.1666666667%
    }

    .el-col-14 {
      max-width: 58.3333333333%;
      flex: 0 0 58.3333333333%
    }

    .el-col-offset-14 {
      margin-left: 58.3333333333%
    }

    .el-col-pull-14 {
      position: relative;
      right: 58.3333333333%
    }

    .el-col-push-14 {
      position: relative;
      left: 58.3333333333%
    }

    .el-col-15 {
      max-width: 62.5%;
      flex: 0 0 62.5%
    }

    .el-col-offset-15 {
      margin-left: 62.5%
    }

    .el-col-pull-15 {
      position: relative;
      right: 62.5%
    }

    .el-col-push-15 {
      position: relative;
      left: 62.5%
    }

    .el-col-16 {
      max-width: 66.6666666667%;
      flex: 0 0 66.6666666667%
    }

    .el-col-offset-16 {
      margin-left: 66.6666666667%
    }

    .el-col-pull-16 {
      position: relative;
      right: 66.6666666667%
    }

    .el-col-push-16 {
      position: relative;
      left: 66.6666666667%
    }

    .el-col-17 {
      max-width: 70.8333333333%;
      flex: 0 0 70.8333333333%
    }

    .el-col-offset-17 {
      margin-left: 70.8333333333%
    }

    .el-col-pull-17 {
      position: relative;
      right: 70.8333333333%
    }

    .el-col-push-17 {
      position: relative;
      left: 70.8333333333%
    }

    .el-col-18 {
      max-width: 75%;
      flex: 0 0 75%
    }

    .el-col-offset-18 {
      margin-left: 75%
    }

    .el-col-pull-18 {
      position: relative;
      right: 75%
    }

    .el-col-push-18 {
      position: relative;
      left: 75%
    }

    .el-col-19 {
      max-width: 79.1666666667%;
      flex: 0 0 79.1666666667%
    }

    .el-col-offset-19 {
      margin-left: 79.1666666667%
    }

    .el-col-pull-19 {
      position: relative;
      right: 79.1666666667%
    }

    .el-col-push-19 {
      position: relative;
      left: 79.1666666667%
    }

    .el-col-20 {
      max-width: 83.3333333333%;
      flex: 0 0 83.3333333333%
    }

    .el-col-offset-20 {
      margin-left: 83.3333333333%
    }

    .el-col-pull-20 {
      position: relative;
      right: 83.3333333333%
    }

    .el-col-push-20 {
      position: relative;
      left: 83.3333333333%
    }

    .el-col-21 {
      max-width: 87.5%;
      flex: 0 0 87.5%
    }

    .el-col-offset-21 {
      margin-left: 87.5%
    }

    .el-col-pull-21 {
      position: relative;
      right: 87.5%
    }

    .el-col-push-21 {
      position: relative;
      left: 87.5%
    }

    .el-col-22 {
      max-width: 91.6666666667%;
      flex: 0 0 91.6666666667%
    }

    .el-col-offset-22 {
      margin-left: 91.6666666667%
    }

    .el-col-pull-22 {
      position: relative;
      right: 91.6666666667%
    }

    .el-col-push-22 {
      position: relative;
      left: 91.6666666667%
    }

    .el-col-23 {
      max-width: 95.8333333333%;
      flex: 0 0 95.8333333333%
    }

    .el-col-offset-23 {
      margin-left: 95.8333333333%
    }

    .el-col-pull-23 {
      position: relative;
      right: 95.8333333333%
    }

    .el-col-push-23 {
      position: relative;
      left: 95.8333333333%
    }

    .el-col-24 {
      max-width: 100%;
      flex: 0 0 100%
    }

    .el-col-offset-24 {
      margin-left: 100%
    }

    .el-col-pull-24 {
      position: relative;
      right: 100%
    }

    .el-col-push-24 {
      position: relative;
      left: 100%
    }

    @media only screen and (max-width:767px) {
      .el-col-xs-0 {
        display: none
      }

      .el-col-xs-0.is-guttered {
        display: none
      }

      .el-col-xs-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-xs-offset-0 {
        margin-left: 0
      }

      .el-col-xs-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-xs-push-0 {
        position: relative;
        left: 0
      }

      .el-col-xs-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-xs-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-xs-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-xs-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-xs-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-xs-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-xs-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-xs-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-xs-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-xs-offset-3 {
        margin-left: 12.5%
      }

      .el-col-xs-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-xs-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-xs-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-xs-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-xs-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-xs-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-xs-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-xs-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-xs-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-xs-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-xs-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-xs-offset-6 {
        margin-left: 25%
      }

      .el-col-xs-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-xs-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-xs-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-xs-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-xs-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-xs-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-xs-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-xs-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-xs-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-xs-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-xs-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-xs-offset-9 {
        margin-left: 37.5%
      }

      .el-col-xs-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-xs-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-xs-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-xs-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-xs-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-xs-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-xs-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-xs-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-xs-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-xs-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-xs-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-xs-offset-12 {
        margin-left: 50%
      }

      .el-col-xs-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-xs-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-xs-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-xs-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-xs-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-xs-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-xs-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-xs-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-xs-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-xs-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-xs-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-xs-offset-15 {
        margin-left: 62.5%
      }

      .el-col-xs-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-xs-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-xs-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-xs-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-xs-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-xs-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-xs-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-xs-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-xs-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-xs-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-xs-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-xs-offset-18 {
        margin-left: 75%
      }

      .el-col-xs-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-xs-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-xs-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-xs-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-xs-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-xs-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-xs-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-xs-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-xs-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-xs-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-xs-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-xs-offset-21 {
        margin-left: 87.5%
      }

      .el-col-xs-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-xs-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-xs-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-xs-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-xs-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-xs-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-xs-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-xs-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-xs-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-xs-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-xs-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-xs-offset-24 {
        margin-left: 100%
      }

      .el-col-xs-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-xs-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:768px) {
      .el-col-sm-0 {
        display: none
      }

      .el-col-sm-0.is-guttered {
        display: none
      }

      .el-col-sm-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-sm-offset-0 {
        margin-left: 0
      }

      .el-col-sm-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-sm-push-0 {
        position: relative;
        left: 0
      }

      .el-col-sm-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-sm-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-sm-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-sm-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-sm-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-sm-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-sm-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-sm-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-sm-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-sm-offset-3 {
        margin-left: 12.5%
      }

      .el-col-sm-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-sm-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-sm-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-sm-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-sm-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-sm-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-sm-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-sm-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-sm-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-sm-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-sm-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-sm-offset-6 {
        margin-left: 25%
      }

      .el-col-sm-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-sm-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-sm-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-sm-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-sm-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-sm-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-sm-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-sm-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-sm-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-sm-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-sm-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-sm-offset-9 {
        margin-left: 37.5%
      }

      .el-col-sm-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-sm-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-sm-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-sm-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-sm-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-sm-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-sm-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-sm-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-sm-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-sm-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-sm-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-sm-offset-12 {
        margin-left: 50%
      }

      .el-col-sm-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-sm-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-sm-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-sm-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-sm-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-sm-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-sm-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-sm-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-sm-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-sm-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-sm-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-sm-offset-15 {
        margin-left: 62.5%
      }

      .el-col-sm-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-sm-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-sm-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-sm-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-sm-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-sm-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-sm-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-sm-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-sm-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-sm-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-sm-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-sm-offset-18 {
        margin-left: 75%
      }

      .el-col-sm-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-sm-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-sm-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-sm-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-sm-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-sm-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-sm-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-sm-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-sm-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-sm-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-sm-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-sm-offset-21 {
        margin-left: 87.5%
      }

      .el-col-sm-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-sm-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-sm-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-sm-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-sm-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-sm-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-sm-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-sm-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-sm-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-sm-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-sm-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-sm-offset-24 {
        margin-left: 100%
      }

      .el-col-sm-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-sm-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:992px) {
      .el-col-md-0 {
        display: none
      }

      .el-col-md-0.is-guttered {
        display: none
      }

      .el-col-md-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-md-offset-0 {
        margin-left: 0
      }

      .el-col-md-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-md-push-0 {
        position: relative;
        left: 0
      }

      .el-col-md-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-md-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-md-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-md-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-md-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-md-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-md-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-md-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-md-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-md-offset-3 {
        margin-left: 12.5%
      }

      .el-col-md-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-md-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-md-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-md-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-md-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-md-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-md-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-md-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-md-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-md-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-md-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-md-offset-6 {
        margin-left: 25%
      }

      .el-col-md-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-md-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-md-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-md-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-md-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-md-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-md-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-md-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-md-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-md-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-md-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-md-offset-9 {
        margin-left: 37.5%
      }

      .el-col-md-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-md-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-md-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-md-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-md-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-md-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-md-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-md-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-md-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-md-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-md-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-md-offset-12 {
        margin-left: 50%
      }

      .el-col-md-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-md-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-md-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-md-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-md-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-md-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-md-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-md-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-md-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-md-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-md-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-md-offset-15 {
        margin-left: 62.5%
      }

      .el-col-md-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-md-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-md-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-md-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-md-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-md-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-md-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-md-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-md-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-md-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-md-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-md-offset-18 {
        margin-left: 75%
      }

      .el-col-md-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-md-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-md-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-md-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-md-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-md-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-md-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-md-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-md-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-md-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-md-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-md-offset-21 {
        margin-left: 87.5%
      }

      .el-col-md-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-md-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-md-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-md-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-md-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-md-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-md-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-md-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-md-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-md-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-md-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-md-offset-24 {
        margin-left: 100%
      }

      .el-col-md-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-md-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:1200px) {
      .el-col-lg-0 {
        display: none
      }

      .el-col-lg-0.is-guttered {
        display: none
      }

      .el-col-lg-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-lg-offset-0 {
        margin-left: 0
      }

      .el-col-lg-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-lg-push-0 {
        position: relative;
        left: 0
      }

      .el-col-lg-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-lg-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-lg-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-lg-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-lg-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-lg-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-lg-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-lg-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-lg-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-lg-offset-3 {
        margin-left: 12.5%
      }

      .el-col-lg-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-lg-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-lg-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-lg-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-lg-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-lg-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-lg-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-lg-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-lg-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-lg-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-lg-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-lg-offset-6 {
        margin-left: 25%
      }

      .el-col-lg-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-lg-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-lg-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-lg-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-lg-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-lg-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-lg-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-lg-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-lg-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-lg-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-lg-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-lg-offset-9 {
        margin-left: 37.5%
      }

      .el-col-lg-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-lg-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-lg-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-lg-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-lg-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-lg-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-lg-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-lg-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-lg-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-lg-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-lg-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-lg-offset-12 {
        margin-left: 50%
      }

      .el-col-lg-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-lg-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-lg-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-lg-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-lg-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-lg-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-lg-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-lg-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-lg-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-lg-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-lg-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-lg-offset-15 {
        margin-left: 62.5%
      }

      .el-col-lg-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-lg-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-lg-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-lg-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-lg-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-lg-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-lg-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-lg-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-lg-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-lg-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-lg-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-lg-offset-18 {
        margin-left: 75%
      }

      .el-col-lg-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-lg-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-lg-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-lg-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-lg-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-lg-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-lg-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-lg-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-lg-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-lg-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-lg-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-lg-offset-21 {
        margin-left: 87.5%
      }

      .el-col-lg-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-lg-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-lg-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-lg-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-lg-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-lg-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-lg-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-lg-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-lg-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-lg-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-lg-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-lg-offset-24 {
        margin-left: 100%
      }

      .el-col-lg-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-lg-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:1920px) {
      .el-col-xl-0 {
        display: none
      }

      .el-col-xl-0.is-guttered {
        display: none
      }

      .el-col-xl-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-xl-offset-0 {
        margin-left: 0
      }

      .el-col-xl-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-xl-push-0 {
        position: relative;
        left: 0
      }

      .el-col-xl-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-xl-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-xl-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-xl-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-xl-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-xl-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-xl-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-xl-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-xl-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-xl-offset-3 {
        margin-left: 12.5%
      }

      .el-col-xl-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-xl-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-xl-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-xl-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-xl-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-xl-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-xl-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-xl-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-xl-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-xl-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-xl-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-xl-offset-6 {
        margin-left: 25%
      }

      .el-col-xl-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-xl-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-xl-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-xl-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-xl-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-xl-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-xl-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-xl-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-xl-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-xl-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-xl-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-xl-offset-9 {
        margin-left: 37.5%
      }

      .el-col-xl-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-xl-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-xl-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-xl-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-xl-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-xl-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-xl-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-xl-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-xl-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-xl-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-xl-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-xl-offset-12 {
        margin-left: 50%
      }

      .el-col-xl-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-xl-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-xl-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-xl-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-xl-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-xl-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-xl-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-xl-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-xl-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-xl-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-xl-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-xl-offset-15 {
        margin-left: 62.5%
      }

      .el-col-xl-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-xl-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-xl-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-xl-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-xl-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-xl-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-xl-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-xl-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-xl-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-xl-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-xl-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-xl-offset-18 {
        margin-left: 75%
      }

      .el-col-xl-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-xl-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-xl-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-xl-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-xl-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-xl-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-xl-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-xl-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-xl-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-xl-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-xl-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-xl-offset-21 {
        margin-left: 87.5%
      }

      .el-col-xl-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-xl-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-xl-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-xl-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-xl-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-xl-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-xl-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-xl-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-xl-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-xl-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-xl-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-xl-offset-24 {
        margin-left: 100%
      }

      .el-col-xl-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-xl-push-24 {
        position: relative;
        left: 100%
      }
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/src/views/login/index.vue?vue&amp;type=style&amp;index=0&amp;scoped=2bf2fc29&amp;lang.scss"">
    .login-container[data-v-2bf2fc29] {
      width: 100%;
      height: 100vh;
      background: url('data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/7gAOQWRvYmUAZMAAAAAB/9sAhAAIBgYHBgUIBwcHCQkICgwUDQwLCwwZEhMPFB0aHx4dGhwcICQuJyAiLCMcHCg3KSwwMTQ0NB8nOT04MjwuMzQyAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wgARCAQ4B4ADASIAAhEBAxEB/8QAHAABAQADAQEBAQAAAAAAAAAAAAECAwQFBgcI/9oACAEBAAAAAOcAAAAAAQAgCAQCAgIEEZ+h0ABQAFAAoMfF40ECCBBAggQermhCEREJCIiIiIhIRER7gAAAAAAgCAIAgICAgQIOnvzAUACgAUDR4uhBBAggIIEED2EEQiISEREREQkQiIhHuAAAAAAGOMxxmMkQFtyuWWQICAgQIEvb20KAAoAKB53lYoEEECBAgQQX10IhEQiIiISIRERERCJ7oAAAAAwxwxxxCCCCCDPPPPICBAgQEM+3rpQAKAAU0eRykCCBBAggQIJl68IREIiIRIREREREIiI90AAAAGGGGCCCCCCCBBdmzbUCAgQIEz7OzMABQAUa/M8+ECCBAgggIEIy9YiEQiIRIREREREIiIie8AAAAxwwwgggggQggQgM922kBBAQIHT19NAKACjR5/BiEEECBBAggQIewhEQiIRERERERCQiIiPeAAADHXhiQQQQIIIIIIIG3dsBAgQIIMunp6MwoADDj4eZAgggQIIECCBB61IREIiIiIiIiIRERERPfAAAY68MQgggQQgQQQQQQZb91QIECBBBt379u3OgJp08/LoEECBAgggIIIEE9PaiEQiIiIhESIhEQiJEe+AAEw14oEECCCCCCCCBCCF39AIECCCBAZ52yY68BAggQQQIECBBBBHd1QiIREREJCIiIiIhEiJ9AAAY68IIEEEEEEEECECECCZb99QIEECCCAggQQQIIIECBAgQQh0d5EIiEiERERERCQiIkSfQgAYa8YCCCCCCBCCCBCBBBBl07QggIIEECCBAghAgQIIECBBCC+shEREQiIiIiEhERESIn0IAa9cIEIEEECECECEECCBBGzqzgQEEECBBAgQQQIIEECCBAghHo7iIhEREREREIiIhIiRJ9EAa9cEECCCCBCCBBBBBAgggdHQEECBAgggQIIEIECCBAgQQgh0d6IhERERCQiIiIRIiRI+iA164EECCBBBCBBBBBBAggghn15kEECBBBAggQQIEECBAggghA9TIiIiIhIRERERCIkRIk+jDDXECCCBCCBBBBBBBAgggggOrcECBBBAggQQIIEEECAgQQhBHT3IiISERERERCQiIkSJH0ZjqhBAggQQgQQQIIQQQIIIECN3VUCCBBAgQQQIIECCBAgQgghB6eaIhERERERCIiIiRIkT6Sa8BAggQQQQIQIIIIIIEIIECEz7M4IIEECCBAgggQIIEECBCECI2+iQiIiIiIRIREREiJEk+hwgQQQQIEEIIEEEIEBTGIECEEL17SBAggQQQIIIECCBAgQQQhBDq7ERERERCQiIiEiJEiSPegQQIIIEIEEEEEEEDLLKzHDCCBBBCOrogQQIEECCCCAgggIIEEEIIQjt6URCIkIiIiIREiJIkSe8ECCCCBBBBBBBBBAy2bdtmrTrwiCBCCDo6RAgQgQIIIECCCAggQQQghCDt6EQiQiIiIiEREiRJEj3hAgggQgQQQIQIQQLs39PTt183Lz6sUEEEIQ39YhAhAgQIIIEECCAgQQhBCCEdPYhERERERCIiJEiRJE98ggIIIIIIIEIIIEDLd09/ob9PB5/JowhAgghCb+sIIECBCBBAggQIECCCIIIQhM+3aiIiIREREREiJEkST6BAgQQQQIIIIIIIIIz39nper28nleZxc+uEEEIIQ3dggggQQQIECECBBAgQQhBCEITb07iISERERCREiRJEkfQIIEEECEEECECCCCGe/r9H0+vn8vzePn1wghBCEI3dsCBBBAgggQIICCBBBCEEIQhCXdt25IREREQiREkSRIk+gCBBBBAhAgggggggy29Pb27tXFxcunWQQQhCEJ0dYQQQQIICCCBBAgQIQghCEIQhC7NmzZYiIRERIkSRJEk+hECCBCBBBBBAhBBAue7fv2YaOfRrxQQQhBEEdPUQQIIIECCBBAgQQIQQhCEIQhCIM927NIhERIkSJJEkfQiCBBBBBBAghBAggjLPZss16sMIEEEIQiEdm8IIIECAEIggQIIIIIQgiCIQhCIRs6dpEREiJIkiSJPoiCCBAhAgghAggggguVsxxxQIQQhCEQd20ggQQIKUkiQQQIIEEIIghCEQhCEQ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');
      background-size: cover;
    }

    .login-container .login-form[data-v-2bf2fc29] {
      position: relative;
      width: 60%;
      top: 30vh;
      background: url('data:image/png;base64,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') no-repeat;
      background-size: cover;
      padding: 40px;
    }

    .login-container .login-form h1[data-v-2bf2fc29] {
      color: white;
      font-size: 40px;
    }

    .login-container .login-form h2[data-v-2bf2fc29] {
      font-size: 20px;
      color: white;
      margin: 20px 0px;
    }

    .login-container .login-form .login-btn[data-v-2bf2fc29] {
      width: 100%;
    }
  </style>
</head>

<body>
  <div class=""app"" id=""app"" data-v-app="""">
    <div data-v-2bf2fc29="""" class=""login-container"">
      <div data-v-2bf2fc29="""" class=""el-row"">
        <div data-v-2bf2fc29="""" class=""el-col el-col-12 el-col-xs-0""></div>
        <div data-v-2bf2fc29="""" class=""el-col el-col-12 el-col-xs-24"">
          <form form action=""{0}account/login"" method=""post"" data-v-2bf2fc29="""" class=""el-form el-form--default el-form--label-right login-form"">
            <h1 data-v-2bf2fc29="""">Hello</h1>
            <h2 data-v-2bf2fc29="""">欢迎来到Scheduler</h2>
            <div data-v-2bf2fc29="""" class=""el-form-item is-required asterisk-left"">
              <div class=""el-form-item__content"">
                <div data-v-2bf2fc29="""" class=""el-input el-input--prefix"">
                  <div class=""el-input__wrapper"" tabindex=""-1"">
                    <span class=""el-input__prefix"">
                      <span class=""el-input__prefix-inner"">
                        <i class=""el-icon el-input__icon"">
                          <svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 1024 1024"">
                            <path fill=""currentColor""
                              d=""M512 512a192 192 0 1 0 0-384 192 192 0 0 0 0 384m0 64a256 256 0 1 1 0-512 256 256 0 0 1 0 512m320 320v-96a96 96 0 0 0-96-96H288a96 96 0 0 0-96 96v96a32 32 0 1 1-64 0v-96a160 160 0 0 1 160-160h448a160 160 0 0 1 160 160v96a32 32 0 1 1-64 0"">
                            </path>
                          </svg></i></span></span><input name=""username"" class=""el-input__inner"" maxlength=""32"" type=""text""
                      autocomplete=""off"" tabindex=""0"" placeholder=""请输入账号""
                      id=""el-id-318-3""><!-- suffix slot --><!--v-if-->
                  </div><!-- append slot --><!--v-if-->
                </div>
              </div>
            </div>
            <div data-v-2bf2fc29="""" class=""el-form-item is-required asterisk-left""><!--v-if-->
              <div class=""el-form-item__content"">
                <div data-v-2bf2fc29="""" class=""el-input el-input--prefix""><!-- input --><!-- prepend slot --><!--v-if-->
                  <div class=""el-input__wrapper"" tabindex=""-1""><!-- prefix slot --><span class=""el-input__prefix""><span
                        class=""el-input__prefix-inner""><i class=""el-icon el-input__icon""><svg
                            xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 1024 1024"">
                            <path fill=""currentColor""
                              d=""M224 448a32 32 0 0 0-32 32v384a32 32 0 0 0 32 32h576a32 32 0 0 0 32-32V480a32 32 0 0 0-32-32zm0-64h576a96 96 0 0 1 96 96v384a96 96 0 0 1-96 96H224a96 96 0 0 1-96-96V480a96 96 0 0 1 96-96"">
                            </path>
                            <path fill=""currentColor""
                              d=""M512 544a32 32 0 0 1 32 32v192a32 32 0 1 1-64 0V576a32 32 0 0 1 32-32m192-160v-64a192 192 0 1 0-384 0v64zM512 64a256 256 0 0 1 256 256v128H256V320A256 256 0 0 1 512 64"">
                            </path>
                          </svg></i></span></span><input name=""pwd"" class=""el-input__inner"" maxlength=""32"" type=""password""
                      autocomplete=""off"" tabindex=""0"" placeholder=""请输入密码""
                      id=""el-id-318-4""><!-- suffix slot --><!--v-if--></div><!-- append slot --><!--v-if-->
                </div>
              </div>
            </div>
            <div data-v-2bf2fc29="""" class=""el-form-item asterisk-left""><!--v-if-->
              <div class=""el-form-item__content""><button data-v-2bf2fc29="""" aria-disabled=""false"" type=""submit""
                  class=""el-button el-button--primary el-button--default login-btn""><!--v-if--><span class=""""> 登录
                  </span></button></div>
            </div>
          </form>
        </div>
        <div data-v-2bf2fc29="""" class=""el-col el-col-24""></div>
      </div>
    </div>
  </div>
</body>
</html>";
    }
}