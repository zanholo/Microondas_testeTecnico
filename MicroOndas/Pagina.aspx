<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina.aspx.cs" Inherits="MicroOndas.Pagina" %>

<!DOCTYPE html>
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Microondas Fábio Zanholo</title>

</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="scrpt"></asp:ScriptManager>

        <div>
            <table>
                <tr>
                    <td>Produto:
                    </td>
                    <td>Instrução:
                    </td>
                    <td>Tempo:
                    </td>
                    <td>Potência:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel runat="server" ID="updatePanel1">
                            <ContentTemplate>
                                <asp:TextBox ID="txtProduto" runat="server" Width="250px"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInstrucao" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTempo" runat="server" placeholder="Numero entre 1 e 120 segundos" MaxLength="3" Width="108px"></asp:TextBox>
                        <asp:Label runat="server" ID="lblTempo" Visible="false"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPotencia" placeholder="Numero entre 1 e 10" MaxLength="2" value="10" Height="18px" Width="64px"></asp:TextBox>
                        <asp:Label runat="server" ID="lblPotencia" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:DropDownList runat="server" ID="ddlProdutos" AutoPostBack="True" OnSelectedIndexChanged="AlteraProgramacao" ViewStateMode="Enabled"></asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnIniciar" runat="server" Text="Aquecimento" OnClick="btnIniciar_Click"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="btnRapidoAquecimento" runat="server" Text="Rápido Aquecimento" OnClick="btnRapidoAquecimento_Click"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="btnParar" runat="server" Text="Parar" OnClick="btnParar_Click"></asp:Button>
                        <asp:Button ID="btnPausar" runat="server" Text="Pausar" OnClick="btnPausar_Click"></asp:Button>
                        <asp:Button ID="btnRetomar" runat="server" Text="Retomar" OnClick="btnRetomar_Click" Visible="false"></asp:Button></td>
                    <td>
                        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click"></asp:Button></td>
                </tr>
            </table>

            <asp:UpdatePanel runat="server" ID="updatePanel">
                <ContentTemplate>
                    <asp:Timer runat="server" ID="tmrTimer" Interval="1000" OnTick="Timer" Enabled="false"></asp:Timer>
                    <asp:Label runat="server" ID="lblTimer" Visible="false"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <br />
        <asp:Panel ID="pnlMensagem" runat="server" Visible="false">
            <div style="align-content:center">
                <asp:Label ID="lblMensagemFinalizacao" Style="text-align: center" runat="server" Text="Label" Font-Bold="True" ForeColor="Red"></asp:Label>
            </div>
        </asp:Panel>
        <br />
        <br />
        <br />




        <span>Cadastro Novo Produto</span>
        <table>
            <tr>
                <td>Produto:
                </td>
                <td>Instrução:
                </td>
                <td>Tempo:
                </td>
                <td>Potência:
                </td>
                <td>Caractere</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtProdCad" runat="server" Width="250px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtInstCad" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtTempoCad" runat="server" placeholder="Numero entre 1 e 120 segundos" MaxLength="3" Width="108px"></asp:TextBox>
                    <asp:Label runat="server" ID="lblcadTempo" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPotCad" placeholder="Numero entre 1 e 10" MaxLength="2" Height="18px" Width="64px"></asp:TextBox>
                    <asp:Label runat="server" ID="lblCadPot" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCarCad" placeholder="Apenas um caracatere." MaxLength="1" Height="18px" Width="64px"></asp:TextBox>
                    <asp:Label runat="server" ID="lblCadCara" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click"></asp:Button>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
