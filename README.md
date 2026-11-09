# App Hotel (.NET MAUI)

Aplicativo mobile feito com .NET MAUI para a atividade da Agenda 13 (Imagens e Componentes Diversos de Interface Gráfica) do curso Técnico em Desenvolvimento de Sistemas, componente Programação Mobile I.

O app calcula o valor da hospedagem de acordo com a suíte escolhida, a quantidade de pessoas e o período da estadia.

## O que o app faz

- Tela de contratação com Stepper (adultos e crianças), Picker (suítes) e DatePicker (check-in e check-out)
- Validação dos campos antes de avançar
- Envio dos dados para a tela de resumo usando BindingContext
- Tela de resumo com suíte, quantidade de pessoas, datas, dias de estadia e valor total
- Tela **Sobre** com informações do desenvolvedor e do projeto
- Layout personalizado com tema azul turquesa e título "Hotel Vitor"

## Telas

| Tela | Descrição |
| --- | --- |
| Cálculo da Diária | Formulário de contratação da hospedagem |
| Hospedagem Contratada | Resumo com o valor total |
| Sobre | Nome do desenvolvedor, ano e tecnologia usada |

## Tecnologias

- .NET 8 (SDK 8.0.427)
- .NET MAUI
- C# e XAML
- Visual Studio 2022

## Como executar

1. Instale o SDK do .NET 8.0.427 e o workload do MAUI (`dotnet workload install maui-windows`).
2. Abra o arquivo `MauiAppHotel.sln` no Visual Studio.
3. Selecione **Debug** e **Windows Machine**.
4. Aperte F5 para executar.

O arquivo `global.json` na raiz do projeto trava a versão do SDK em 8.0.427. O projeto está configurado para rodar no Windows.

## Estrutura

```
MauiAppHotel/
  Models/        Quarto e Hospedagem
  Views/         ContratacaoHospedagem, HospedagemContratada e Sobre
  Resources/     Cores, estilos, fontes e imagens
global.json      Versão do SDK
```

## Autor

Vitor, 2026
