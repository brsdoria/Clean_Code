using CleanCode.M08_Emergencia_E_Refinamento_Refactor_4;

var data = new DataUtils(24, 04, 1982);
var bissexto = data.EhAnoBissexto();
var dias = data.ObterDiasNoMes();

Console.WriteLine($"A data {data} possui {dias} dias no mês e o resultado para ano Bissexto é {bissexto}");
