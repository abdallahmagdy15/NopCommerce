/*
** nopCommerce city select js functions
*/
console.log("cityselect script loaded");////////log

+function ($) {
    'use strict';
    if ('undefined' == typeof (jQuery)) {
        throw new Error('jQuery JS required');
    }
  function citySelectHandler() {
    console.log("citySelectHandler fired");////////log
    console.log("citySelectHandler this : ",this);
        var $this = $(this);
        var selectedItem = $this.val();
        var district = $($this.data('district'));
        var loading = $($this.data('loading'));
        loading.show();
        $.ajax({
            cache: false,
            type: "GET",
            url: $this.data('url'),
            data: { 
              'cityId': selectedItem,
              'addSelectDistrictItem': "true"
            },
            success: function (data, textStatus, jqXHR) {
                district.html('');
                $.each(data,
                    function (id, option) {
                        district.append($('<option></option>').val(option.id).html(option.name));
                    });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('Failed to retrieve districts.');
            },
            complete: function(jqXHR, textStatus) {
              var districtId = (typeof Billing !== "undefined") ? Billing.selectedDistrictId : (typeof CheckoutBilling !== "undefined") ? CheckoutBilling.selectedDistrictId : 0;
              $('#' + district[0].id + ' option[value=' + districtId + ']').prop('selected', true);

              loading.hide();
            }
        });
    }
  if ($(document).has('[data-trigger="city-select"]')) {
    console.log("city select trigger");////////log

    $('select[data-trigger="city-select"]').change(citySelectHandler);
    console.log("on change city ",$('select[data-trigger="city-select"]'));
    }
  $.fn.citySelect = function () {
    console.log("this of fn.citySelect", this);
        this.each(function () {
          $(this).change(citySelectHandler);

        });
    }
}(jQuery); 