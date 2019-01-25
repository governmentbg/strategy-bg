(function(){function r(e,n,t){function o(i,f){if(!n[i]){if(!e[i]){var c="function"==typeof require&&require;if(!f&&c)return c(i,!0);if(u)return u(i,!0);var a=new Error("Cannot find module '"+i+"'");throw a.code="MODULE_NOT_FOUND",a}var p=n[i]={exports:{}};e[i][0].call(p.exports,function(r){var n=e[i][1][r];return o(n||r)},p,p.exports,r,e,n,t)}return n[i].exports}for(var u="function"==typeof require&&require,i=0;i<t.length;i++)o(t[i]);return o}return r})()({1:[function(require,module,exports){
'use strict';

require('./modules/script.js');

},{"./modules/script.js":2}],2:[function(require,module,exports){
'use strict';
// import debounce from './debounce.js';

(function () {
  /* INIT SWIPER */
  var swiper = new Swiper('.swiper-container', {
    slidesPerView: 1,
    spaceBetween: 30,
    slidesPerGroup: 1,
    loop: true,
    loopFillGroupWithBlank: true,
    autoplay: {
      delay: 2500,
      disableOnInteraction: false
    }
  });
  /* END INIT SWIPER */

  /* HEADER NAV MENU */

  var button_menu = document.querySelector('button.menu');
  var navigation = document.querySelector('.header--main nav');

  function resize_navigation() {
    var header = document.querySelector('.header--main');
    var body = document.querySelector('.body');
    var top = header.offsetTop + header.offsetHeight;;
    var height = body.offsetHeight;
    navigation.setAttribute('style', 'top:' + top + 'px;height:' + height + 'px;');
  }
  function reset_resize_navigation() {
    navigation.style.height = 'auto';
  }
  button_menu && button_menu.addEventListener('click', function (e) {
    if (!navigation.classList.contains('active')) {
      resize_navigation();
    }
    e.currentTarget.classList.toggle('active');
    navigation.classList.toggle('active');
  });
  /* END HEADER NAV MENU */

  window.addEventListener('resize', function (e) {
    if (e.currentTarget.innerWidth >= 972) reset_resize_navigation();else resize_navigation();
  });
})();

},{}]},{},[1])
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIm5vZGVfbW9kdWxlcy9icm93c2VyLXBhY2svX3ByZWx1ZGUuanMiLCJjbGllbnQvanMvY29uZmlnLmpzIiwiY2xpZW50L2pzL21vZHVsZXMvc2NyaXB0LmpzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBOzs7QUNBQSxRQUFRLHFCQUFSOzs7QUNBQTtBQUNBOztBQUVBLENBQUMsWUFBVztBQUNaO0FBQ0UsTUFBSSxTQUFTLElBQUksTUFBSixDQUFXLG1CQUFYLEVBQWdDO0FBQzNDLG1CQUFnQixDQUQyQjtBQUUzQyxrQkFBZSxFQUY0QjtBQUczQyxvQkFBaUIsQ0FIMEI7QUFJM0MsVUFBTyxJQUpvQztBQUszQyw0QkFBeUIsSUFMa0I7QUFNM0MsY0FBVTtBQUNSLGFBQU8sSUFEQztBQUVSLDRCQUFzQjtBQUZkO0FBTmlDLEdBQWhDLENBQWI7QUFXRjs7QUFFQTs7QUFHRSxNQUFJLGNBQWMsU0FBUyxhQUFULENBQXVCLGFBQXZCLENBQWxCO0FBQ0EsTUFBSSxhQUFhLFNBQVMsYUFBVCxDQUF1QixtQkFBdkIsQ0FBakI7O0FBRUEsV0FBUyxpQkFBVCxHQUE2QjtBQUMzQixRQUFJLFNBQVMsU0FBUyxhQUFULENBQXVCLGVBQXZCLENBQWI7QUFDQSxRQUFJLE9BQU8sU0FBUyxhQUFULENBQXVCLE9BQXZCLENBQVg7QUFDQSxRQUFJLE1BQU0sT0FBTyxTQUFQLEdBQW1CLE9BQU8sWUFBcEMsQ0FBaUQ7QUFDakQsUUFBSSxTQUFTLEtBQUssWUFBbEI7QUFDQSxlQUFXLFlBQVgsQ0FBd0IsT0FBeEIsRUFBaUMsU0FBTyxHQUFQLEdBQWEsWUFBYixHQUEwQixNQUExQixHQUFpQyxLQUFsRTtBQUNEO0FBQ0QsV0FBUyx1QkFBVCxHQUFtQztBQUNqQyxlQUFXLEtBQVgsQ0FBaUIsTUFBakIsR0FBMEIsTUFBMUI7QUFDRDtBQUNELGlCQUFlLFlBQVksZ0JBQVosQ0FBNkIsT0FBN0IsRUFBc0MsVUFBUyxDQUFULEVBQVk7QUFDL0QsUUFBSSxDQUFDLFdBQVcsU0FBWCxDQUFxQixRQUFyQixDQUE4QixRQUE5QixDQUFMLEVBQThDO0FBQzVDO0FBQ0Q7QUFDRCxNQUFFLGFBQUYsQ0FBZ0IsU0FBaEIsQ0FBMEIsTUFBMUIsQ0FBaUMsUUFBakM7QUFDQSxlQUFXLFNBQVgsQ0FBcUIsTUFBckIsQ0FBNEIsUUFBNUI7QUFDRCxHQU5jLENBQWY7QUFPRjs7QUFFRSxTQUFPLGdCQUFQLENBQXdCLFFBQXhCLEVBQWtDLFVBQVMsQ0FBVCxFQUFZO0FBQzVDLFFBQUksRUFBRSxhQUFGLENBQWdCLFVBQWhCLElBQThCLEdBQWxDLEVBQXVDLDBCQUF2QyxLQUNLO0FBQ04sR0FIRDtBQUtELENBN0NEIiwiZmlsZSI6ImdlbmVyYXRlZC5qcyIsInNvdXJjZVJvb3QiOiIiLCJzb3VyY2VzQ29udGVudCI6WyIoZnVuY3Rpb24oKXtmdW5jdGlvbiByKGUsbix0KXtmdW5jdGlvbiBvKGksZil7aWYoIW5baV0pe2lmKCFlW2ldKXt2YXIgYz1cImZ1bmN0aW9uXCI9PXR5cGVvZiByZXF1aXJlJiZyZXF1aXJlO2lmKCFmJiZjKXJldHVybiBjKGksITApO2lmKHUpcmV0dXJuIHUoaSwhMCk7dmFyIGE9bmV3IEVycm9yKFwiQ2Fubm90IGZpbmQgbW9kdWxlICdcIitpK1wiJ1wiKTt0aHJvdyBhLmNvZGU9XCJNT0RVTEVfTk9UX0ZPVU5EXCIsYX12YXIgcD1uW2ldPXtleHBvcnRzOnt9fTtlW2ldWzBdLmNhbGwocC5leHBvcnRzLGZ1bmN0aW9uKHIpe3ZhciBuPWVbaV1bMV1bcl07cmV0dXJuIG8obnx8cil9LHAscC5leHBvcnRzLHIsZSxuLHQpfXJldHVybiBuW2ldLmV4cG9ydHN9Zm9yKHZhciB1PVwiZnVuY3Rpb25cIj09dHlwZW9mIHJlcXVpcmUmJnJlcXVpcmUsaT0wO2k8dC5sZW5ndGg7aSsrKW8odFtpXSk7cmV0dXJuIG99cmV0dXJuIHJ9KSgpIiwicmVxdWlyZSgnLi9tb2R1bGVzL3NjcmlwdC5qcycpO1xuIiwiJ3VzZSBzdHJpY3QnO1xuLy8gaW1wb3J0IGRlYm91bmNlIGZyb20gJy4vZGVib3VuY2UuanMnO1xuXG4oZnVuY3Rpb24oKSB7XG4vKiBJTklUIFNXSVBFUiAqL1xuICB2YXIgc3dpcGVyID0gbmV3IFN3aXBlcignLnN3aXBlci1jb250YWluZXInLCB7XG4gICAgc2xpZGVzUGVyVmlldyA6IDEsXG4gICAgc3BhY2VCZXR3ZWVuIDogMzAsXG4gICAgc2xpZGVzUGVyR3JvdXAgOiAxLFxuICAgIGxvb3AgOiB0cnVlLFxuICAgIGxvb3BGaWxsR3JvdXBXaXRoQmxhbmsgOiB0cnVlLFxuICAgIGF1dG9wbGF5OiB7XG4gICAgICBkZWxheTogMjUwMCxcbiAgICAgIGRpc2FibGVPbkludGVyYWN0aW9uOiBmYWxzZSxcbiAgICB9XG4gIH0pO1xuLyogRU5EIElOSVQgU1dJUEVSICovXG5cbi8qIEhFQURFUiBOQVYgTUVOVSAqL1xuXG5cbiAgdmFyIGJ1dHRvbl9tZW51ID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvcignYnV0dG9uLm1lbnUnKTtcbiAgdmFyIG5hdmlnYXRpb24gPSBkb2N1bWVudC5xdWVyeVNlbGVjdG9yKCcuaGVhZGVyLS1tYWluIG5hdicpO1xuXG4gIGZ1bmN0aW9uIHJlc2l6ZV9uYXZpZ2F0aW9uKCkge1xuICAgIHZhciBoZWFkZXIgPSBkb2N1bWVudC5xdWVyeVNlbGVjdG9yKCcuaGVhZGVyLS1tYWluJyk7XG4gICAgdmFyIGJvZHkgPSBkb2N1bWVudC5xdWVyeVNlbGVjdG9yKCcuYm9keScpO1xuICAgIHZhciB0b3AgPSBoZWFkZXIub2Zmc2V0VG9wICsgaGVhZGVyLm9mZnNldEhlaWdodDs7XG4gICAgdmFyIGhlaWdodCA9IGJvZHkub2Zmc2V0SGVpZ2h0O1xuICAgIG5hdmlnYXRpb24uc2V0QXR0cmlidXRlKCdzdHlsZScsICd0b3A6Jyt0b3AgKyAncHg7aGVpZ2h0OicraGVpZ2h0KydweDsnKTtcbiAgfVxuICBmdW5jdGlvbiByZXNldF9yZXNpemVfbmF2aWdhdGlvbigpIHtcbiAgICBuYXZpZ2F0aW9uLnN0eWxlLmhlaWdodCA9ICdhdXRvJztcbiAgfVxuICBidXR0b25fbWVudSAmJiBidXR0b25fbWVudS5hZGRFdmVudExpc3RlbmVyKCdjbGljaycsIGZ1bmN0aW9uKGUpIHtcbiAgICBpZiAoIW5hdmlnYXRpb24uY2xhc3NMaXN0LmNvbnRhaW5zKCdhY3RpdmUnKSkge1xuICAgICAgcmVzaXplX25hdmlnYXRpb24oKTtcbiAgICB9XG4gICAgZS5jdXJyZW50VGFyZ2V0LmNsYXNzTGlzdC50b2dnbGUoJ2FjdGl2ZScpO1xuICAgIG5hdmlnYXRpb24uY2xhc3NMaXN0LnRvZ2dsZSgnYWN0aXZlJyk7XG4gIH0pO1xuLyogRU5EIEhFQURFUiBOQVYgTUVOVSAqL1xuXG4gIHdpbmRvdy5hZGRFdmVudExpc3RlbmVyKCdyZXNpemUnLCBmdW5jdGlvbihlKSB7XG4gICAgaWYgKGUuY3VycmVudFRhcmdldC5pbm5lcldpZHRoID49IDk3MikgcmVzZXRfcmVzaXplX25hdmlnYXRpb24oKTtcbiAgICBlbHNlIHJlc2l6ZV9uYXZpZ2F0aW9uKCk7XG4gIH0pO1xuXG59KSgpO1xuIl19
