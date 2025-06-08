using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BINGOO_
{
    public partial class Form1 : Form
    {
        // Dicionário que relaciona número a um Label na interface (painel do bingo)
        private Dictionary<int, Label> bingoLabels = new Dictionary<int, Label>();

        // Lista com todos os números ainda não sorteados
        private List<int> numerosRestantes = Enumerable.Range(1, 75).ToList();

        // Gerador de números aleatórios
        private Random random = new Random();

        // Cronômetro para medir a duração do jogo
        private Stopwatch cronometro = new Stopwatch();

        // Lista com os dois últimos números sorteados
        private List<int> ultimosNumeros = new List<int>();

        public Form1()
        {
            InitializeComponent(); 
        }

        // Evento ao carregar o formulário
        private void Form1_Load(object sender, EventArgs e)
        {
            CriarLabelsBingo(); 
            btnSortear.Enabled = false; 
            txtPremio.TextChanged += TxtPremio_TextChanged;
            lblSorteado.BackColor = Color.Transparent;
            lblSorteado.ForeColor = Color.White;
            lblUltimo.BackColor = Color.Transparent;
            lblUltimo.ForeColor = Color.White;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.White;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.White;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
        }

        // Altera a cor de fundo da caixa de texto do prêmio dependendo se está vazia
        private void TxtPremio_TextChanged(object sender, EventArgs e)
        {
            txtPremio.BackColor = string.IsNullOrWhiteSpace(txtPremio.Text) ? Color.LightYellow : SystemColors.Window;
            EstilizarLabelResultado(lblUltimo, 12); 
        }

        
        private void Form1_Resize(object sender, EventArgs e)
        {
            AtualizarTamanhoLabels();
        }

        // ajustar o tamanho das labels
        private void AtualizarTamanhoLabels()
        {
            int colunas = 15;
            int linhas = 5;
            int larguraLabel = panelBingo.ClientSize.Width / colunas;
            int alturaLabel = panelBingo.ClientSize.Height / linhas;

            string[] letras = { "B", "I", "N", "G", "O" };

            for (int i = 0; i < 75; i++)
            {
                int numero = i + 1;
                int coluna = i / 15;
                int linha = i % 15;

                if (bingoLabels.TryGetValue(numero, out Label label))
                {
                    label.Left = linha * larguraLabel;
                    label.Top = coluna * alturaLabel;
                    label.Width = larguraLabel;
                    label.Height = alturaLabel;

                    string letra = letras[coluna];
                    label.Text = $"{letra}{Environment.NewLine}{numero:00}";
                    label.Font = new Font("Segoe UI", alturaLabel / 4f, FontStyle.Bold);
                }
            }
        }

        // Botão para sortear os numeros do bingo
        private void btnSortear_Click(object sender, EventArgs e)
        {
            if (numerosRestantes.Count == 0)
            {
                MessageBox.Show("Todos os números já foram sorteados!");
                return;
            }

            // Sorteia número aleatório da lista restante
            int index = random.Next(numerosRestantes.Count);
            int numeroSorteado = numerosRestantes[index];
            numerosRestantes.RemoveAt(index);

            MarcarNumeroVerde(numeroSorteado); 

            string[] letras = { "B", "I", "N", "G", "O" };
            string letraAtual = letras[(numeroSorteado - 1) / 15];

            // Atualiza o label do número sorteado
            lblSorteado.Text = $"{letraAtual}{Environment.NewLine}{numeroSorteado:00}";
            EstilizarLabelResultado(lblSorteado, 14);

            // Atualiza a lista de últimos números
            ultimosNumeros.Insert(0, numeroSorteado);
            if (ultimosNumeros.Count > 2) ultimosNumeros.RemoveAt(2);

            // mostra o pnultimo numero que foi sorteado para pessoas que comem bronha
            if (ultimosNumeros.Count >= 2)
            {
                int penultimo = ultimosNumeros[1];
                string letraPenultimo = letras[(penultimo - 1) / 15];
                lblUltimo.Text = $"{letraPenultimo}{Environment.NewLine}{penultimo:00}";
            }
            else
            {
                lblUltimo.Text = "";
            }

            EstilizarLabelResultado(lblUltimo, 12);
        }

        // criar as 75 labels com as letras do bingo em um panel
        private void CriarLabelsBingo()
        {
            string[] letras = { "B", "I", "N", "G", "O" };

            for (int i = 0; i < 75; i++)
            {
                int numero = i + 1;
                int coluna = i / 15;
                int linha = i % 15;

                Label label = new Label
                {
                    BorderStyle = BorderStyle.None,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent, //  Transparente
                    ForeColor = Color.White,       // Texto visível
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    AutoSize = false,
                    Text = $"{letras[coluna]}{Environment.NewLine}{numero:00}"
                };

                panelBingo.Controls.Add(label);
                bingoLabels[numero] = label;
            }

            AtualizarTamanhoLabels();
        }

        // marca os numeros sorteados com verde
        private void MarcarNumeroVerde(int numero)
        {
            if (bingoLabels.ContainsKey(numero))
            {
                bingoLabels[numero].BackColor = Color.LimeGreen;
            }
        }

        // Fechar a aplicação
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja visualizar as cartelas salvas antes de sair?", "Finalizar Jogo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string pastaDestino = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CartelaBingo");

                if (Directory.Exists(pastaDestino))
                    Process.Start("explorer.exe", pastaDestino);
                else
                    MessageBox.Show("Ainda não há cartelas salvas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.No)
            {
                this.Close(); // Fecha o aplicativo
            }
        }

        // Começa o jogo depois que o campo do premio foi preenchido
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPremio.Text))
            {
                MessageBox.Show("Por favor, informe o prêmio antes de iniciar o jogo.", "Prêmio obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPremio.Focus();
                return;
            }

            MessageBox.Show("Boa sorte com o BINGO!", "Início do Jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cronometro.Restart(); 
            btnSortear.Enabled = true;
        }

        // A formatação de label
        private void EstilizarLabelResultado(Label label, float tamanhoFonte)
        {
            label.Font = new Font("Segoe UI", tamanhoFonte, FontStyle.Bold);
            label.TextAlign = ContentAlignment.MiddleCenter;
        }

        // Verificação do BINGO
        private void btnBingo_Click(object sender, EventArgs e)
        {
            cronometro.Stop(); 

            // Cria um formulário para digitar os numeros que o jogador marcou
            Form inputForm = new Form { Width = 400, Height = 200, Text = "Validar BINGO" };
            Label lbl = new Label { Left = 10, Top = 20, Width = 360, Text = "Digite os números marcados" };
            TextBox txtInput = new TextBox { Left = 10, Top = 50, Width = 360 };
            Button btnOk = new Button { Text = "Verificar", Left = 150, Width = 100, Top = 90, DialogResult = DialogResult.OK };

            inputForm.Controls.Add(lbl);
            inputForm.Controls.Add(txtInput);
            inputForm.Controls.Add(btnOk);
            inputForm.AcceptButton = btnOk;

            // Verifica se usuário clicou em OK
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                string entrada = txtInput.Text;

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    MessageBox.Show("Nenhum número foi informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cronometro.Start();
                    return;
                }

                // Converte a string para uma lista de inteiros válidos
                List<int> numerosDigitados = entrada.Split(',')
                                                     .Select(parte => int.TryParse(parte.Trim(), out int n) ? n : -1)
                                                     .Where(n => n != -1)
                                                     .ToList();

                // Verifica se tem numeros que não fazem parte do bingo(75 pra cima)
                var numerosInvalidos = numerosDigitados.Where(n => n < 1 || n > 75).ToList();
                if (numerosInvalidos.Any())
                {
                    MessageBox.Show($"Os seguintes números são inválidos: {string.Join(", ", numerosInvalidos)}", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar a cartela digitando os numeros da cartela e comparando com os que ja foram sorteados
                List<int> numerosJaSorteados = Enumerable.Range(1, 75).Except(numerosRestantes).ToList();
                bool valido = numerosDigitados.All(n => numerosJaSorteados.Contains(n));

                TimeSpan tempoJogado = cronometro.Elapsed;
                string tempoFormatado = $"{tempoJogado.Hours:D2}:{tempoJogado.Minutes:D2}:{tempoJogado.Seconds:D2}";

                if (valido)
                {
                    // Form pedindo o nome do ganhador apos validar a cartela e for vencedora
                    Form nomeForm = new Form { Width = 300, Height = 150, Text = "Nome do Vencedor", StartPosition = FormStartPosition.CenterParent };
                    Label lblNome = new Label { Left = 10, Top = 20, Text = "Digite o nome do vencedor:", AutoSize = true };
                    TextBox txtNome = new TextBox { Left = 10, Top = 50, Width = 260 };
                    Button btnNomeOk = new Button { Text = "OK", Left = 100, Top = 80, DialogResult = DialogResult.OK };

                    nomeForm.Controls.Add(lblNome);
                    nomeForm.Controls.Add(txtNome);
                    nomeForm.Controls.Add(btnNomeOk);
                    nomeForm.AcceptButton = btnNomeOk;

                    if (nomeForm.ShowDialog() == DialogResult.OK)
                    {
                        string nomeVencedor = txtNome.Text.Trim();

                        if (string.IsNullOrWhiteSpace(nomeVencedor))
                        {
                            MessageBox.Show("Por favor, digite um nome válido para o vencedor.", "Nome inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Parte para registrar os dados da cartela
                        string horaTermino = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        List<int> numerosSorteados = Enumerable.Range(1, 75).Except(numerosRestantes).ToList();

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"Nome do Vencedor: {nomeVencedor}");
                        sb.AppendLine($"Números da cartela: {string.Join(", ", numerosDigitados)}");
                        sb.AppendLine($"Hora de término: {horaTermino}");
                        sb.AppendLine($"Duração: {tempoFormatado}");
                        sb.AppendLine($"Todos os números sorteados: {string.Join(", ", numerosSorteados)}");

                        // Parte para salvar a cartela de bingo na area de trabalho
                        string pastaDestino = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CartelaBingo");
                        Directory.CreateDirectory(pastaDestino);

                        string nomeArquivo = $"Sorteio_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                        string caminho = Path.Combine(pastaDestino, nomeArquivo);

                        File.WriteAllText(caminho, sb.ToString());

                        MessageBox.Show($"Parabéns {nomeVencedor}! Você completou o BINGO.\nDados salvos em:\n{caminho}", "BINGO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Erro: Um ou mais números informados ainda não foram sorteados.", "BINGO Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cronometro.Start();
                }
            }
            else
            {
                cronometro.Start();
            }
        }
    }
}
