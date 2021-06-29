/*
** nopCommerce city select js functions
*/
+function ($) {
    'use strict';
    if ('undefined' == typeof (jQuery)) {
        throw new Error('jQuery JS required');
    }
    function districtSelectHandler() {
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
              'districtId': selectedItem,
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
                alert('Failed to retrieve states.');
            },
            complete: function(jqXHR, textStatus) {
              var stateId = (typeof Billing !== "undefined") ? Billing.selectedDistrictId : (typeof CheckoutBilling !== "undefined") ? CheckoutBilling.selectedDistrictId : 0;
              $('#' + district[0].id + ' option[value=' + stateId + ']').prop('selected', true);

              loading.hide();
            }
        });
    }
    if ($(document).has('[data-trigger="district-select"]')) {
        $('select[data-trigger="district-select"]').change(districtSelectHandler);
    }
    $.fn.districtSelect = function () {
        this.each(function () {
            $(this).change(districtSelectHandler);
        });
    }
}(jQuery); 