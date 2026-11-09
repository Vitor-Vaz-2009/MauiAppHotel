using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    private readonly List<Quarto> lista_quartos = new()
    {
        new Quarto { Descricao = "Suíte Individual", ValorDiariaAdulto = 120.0, ValorDiariaCrianca = 60.0 },
        new Quarto { Descricao = "Suíte Casal", ValorDiariaAdulto = 180.0, ValorDiariaCrianca = 90.0 },
        new Quarto { Descricao = "Suíte Família", ValorDiariaAdulto = 250.0, ValorDiariaCrianca = 120.0 },
        new Quarto { Descricao = "Suíte Master", ValorDiariaAdulto = 400.0, ValorDiariaCrianca = 200.0 }
    };

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        pck_quarto.ItemsSource = lista_quartos;
        pck_quarto.ItemDisplayBinding = new Binding("Descricao");

        DateTime hoje = DateTime.Today;

        dtpck_checkin.MinimumDate = hoje;
        dtpck_checkin.MaximumDate = hoje.AddYears(1);
        dtpck_checkin.Date = hoje;

        dtpck_checkout.MinimumDate = hoje.AddDays(1);
        dtpck_checkout.MaximumDate = hoje.AddYears(1).AddDays(1);
        dtpck_checkout.Date = hoje.AddDays(1);
    }

    private void dtpck_checkin_DateSelected(object? sender, DateChangedEventArgs e)
    {
        DateTime checkin = e.NewDate;

        dtpck_checkout.MinimumDate = checkin.AddDays(1);
        dtpck_checkout.MaximumDate = checkin.AddYears(1);

        if (dtpck_checkout.Date <= checkin)
            dtpck_checkout.Date = checkin.AddDays(1);
    }

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem is not Quarto quarto)
            {
                await DisplayAlert("Atenção", "Escolha uma suíte.", "OK");
                return;
            }

            if (stp_adultos.Value < 1)
            {
                await DisplayAlert("Atenção", "Informe pelo menos 1 adulto.", "OK");
                return;
            }

            var hospedagem = new Hospedagem
            {
                QuartoSelecionado = quarto,
                QtdAdultos = Convert.ToInt32(stp_adultos.Value),
                QtdCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date
            };

            await Navigation.PushAsync(new HospedagemContratada
            {
                BindingContext = hospedagem
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void Sobre_Clicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}
