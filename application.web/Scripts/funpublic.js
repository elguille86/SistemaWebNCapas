$(document).ready(function () {
    $(".numero").keydown(function(event) {
        if (
                event.keyCode == 46 || event.keyCode == 8 || 
                event.keyCode == 9 || event.keyCode == 37 || 
                event.keyCode == 38 || event.keyCode == 39 || 
                event.keyCode == 40
		) { }
        else {
            if (
                (event.keyCode < 48 || event.keyCode > 57) && 
                (event.keyCode < 96 || event.keyCode > 105)) 
			{
                event.preventDefault();
            }
        }
	});
        
    $.datepicker.regional['es'] = {
        closeText: 'Cerrar', prevText: '<Ant', nextText: 'Sig>', currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene','Feb','Mar','Abr', 'May','Jun','Jul','Ago','Sep', 'Oct','Nov','Dic'], dayNames: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
        dayNamesShort: ['Dom','Lun','Mar','Mie','Juv','Vie','Sab'], dayNamesMin: ['Do','Lu','Ma','Mi','Ju','Vi','Sa'],
        weekHeader: 'Sm', dateFormat: 'dd/mm/yy', firstDay: 1, isRTL: false, showMonthAfterYear: false, yearSuffix: ''
    };
    $.timepicker.regional['es'] = {
            hourText: 'Hora', minuteText: 'Minutos', amPmText: ['AM', 'PM'], closeButtonText: 'Hecho', nowButtonText: 'Ahora', deselectButtonText: 'Deselect' 
    };
    $.datepicker.setDefaults($.datepicker.regional['es']); 
    $.timepicker.setDefaults($.timepicker.regional['es']); 
        
});

function calcular_edad(fecinicio,fecfin,separador) {
    FechaNacFin = fecfin.split(separador);
    var yyyyActual = FechaNacFin[0];
    var mmActual = FechaNacFin[1];
    var diaActual = FechaNacFin[2];
    FechaNac = fecinicio.split(separador);
    var diaCumple = FechaNac[2];
    var mmCumple = FechaNac[1];
    var yyyyCumple = FechaNac[0];
    var ano = yyyyActual - yyyyCumple;
    var mes = 0;   
    if(( fecinicio =="" ) || ( fecfin =="") ){return "Error de Fechas";}  
    if( parseInt(yyyyCumple) > parseInt(yyyyActual) ){ return "Error : F.Nacimiento"; }
    if(parseInt(mmCumple) > parseInt(mmActual)){ mes = 12 - ( parseInt(mmCumple) - parseInt(mmActual) ); ano = ano -1; }
    if(parseInt(mmCumple) < parseInt(mmActual)){ mes = ( parseInt(mmActual) - parseInt(mmCumple)  ) ; }
    if( parseInt(mmCumple) == parseInt(mmActual) ){
        if( parseInt(diaCumple) <= parseInt(diaActual)  ){ mes = 0 ; }
        if( parseInt(diaCumple) > parseInt(diaActual)  ){ ano = ano -1 ; mes = 11 ; }
    } 
    return ano+ ' Años '+ mes+'  Meses';
} 

 // Agragando Metodo de Validacion
jQuery.validator.addMethod(   
	"selectNone",   
   	function(value, element) {   
     	if (element.value == '--'){ return false; }  else return true;   
   	},   
   	"Por favor seleccione una opcion."  
);

jQuery.validator.addMethod(   
	"selectNone2",   
   	function(value, element) {   
     	if (element.value == '----'){ return false; }  else return true;   
   	},   
   	"Por favor seleccione una opcion."  
);

jQuery.validator.addMethod(   
	"selectNone3",   
   	function(value, element) {   
     	if (element.value == '0'){ return false; }  else return true;   
   	},   
   	"Por favor seleccione una opcion."  
);
    
function caldias(ini , fin ){
    // caldias('yyy-mm-dd' , 'yyy-mm-dd' ){
    var ini  = $("#fecing").val() ;
    var fin = $("#fecegre").val() ;
    if (fin != "" && ini != "") {
        var aini = ini.split('-');
        var afin = fin.split('-');
        var fecha1 = aini[1]+'-'+aini[2]+'-'+aini[0];
        var fecha2 = afin[1]+'-'+afin[2]+'-'+afin[0];
        var diferencia =  Math.floor(( Date.parse(fecha2) - Date.parse(fecha1) ) / 86400000);
        if(diferencia < 0){
            diferencia =  diferencia*(-1)    ;
            if (!isNaN(diferencia)) {
                diferencia =  (diferencia/86400000 * -1);     
            }
            else {
                diferencia =  0;    
            }                
        }
        diferencia =  diferencia + 1;
 
        if(diferencia < 1){
            diferencia =0 ;
        }
        return diferencia ;
          
    }  
}
    