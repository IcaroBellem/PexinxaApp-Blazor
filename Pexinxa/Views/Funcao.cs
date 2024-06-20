using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Pexinxa.Views
{
    public class Funcao
    {
        /*public static string MenuSuperior()
        {
            return @"
            <div id='menusup'>
            <img id='menusup' src='images/logo_icon.png' alt='imagem logo pexinxa'>
            <img id='menusup2' src='images/logotipo.png' alt='imagem logotipo pexinxa '>

            <div id='log_cad_box'>
                <span class='material-symbols-outlined'>Account_Circle</span>
                <p id='log_cad'><a id='log_cad'  data-bs-toggle='modal' data-bs-target='#staticBackdrop'  href='cadastro.html'>cadastre-se</a> ou faça <a id='log_cad' href='#exampleModal' data-bs-toggle='modal'>login</a></p>
            </div>


            <div id='barrapesquisa'>

                <input id='pesquisa' type='text' name='barrapesquisa' placeholder='🔍︎ O que você está procurando?' onkeyup='search()'>
                </input>

            </div>

            <div id='menuinferior2'>
            <ul id='ulmenuinf'>
                <li id='limenuinf2'><a asp-area= "" asp-controller = ""Home"" asp-action= ""Index"" id='menu_inf2'><span class='material-symbols-outlined'>home</span>HOME</a></li>
                <li id='limenuinf2'><a asp-area= "" asp-controller = ""Produtos"" asp-action= ""Produtos""   id='menu_inf2'><span class='material-symbols-outlined'>Shopping_cart</span>PRODUTOS</a></li>
                <li id='limenuinf2'><a id='menu_inf2' href='Mercado'><span class='material-symbols-outlined'>storefront</span>MERCADOS</a></li>
                <li id='limenuinf2'><a id='menu_inf2' href='Lista'><span class='material-symbols-outlined'>receipt_long</span>LISTA</a></li>
            </ul>
           
        </div>


            <div id='localizacao'>
            <span class='material-symbols-outlined'>location_on</span><p id='loc'>AV. Judas perdeu as botas, 05 - Matão</p>

                </div>";
        }

        public static string MenuInferior()
        {
            return @"
                 <div id='menuinferior'>
                    <ul id='ulmenuinf'>
                 <li id='limenuinf'><a id='menu_inf' href='index.php'><span class='material-symbols-outlined'>home</span>HOME</a></li>

                 <li id='limenuinf'><a id='menu_inf' href='Produtos.cshtml'><span class='material-symbols-outlined'>Shopping_cart</span>PRODUTOS</a></li>

                 <li id='limenuinf'><a id='menu_inf' href='mercado.php'><span class='material-symbols-outlined'>storefront</span>MERCADOS</a></li>

                 <li id='limenuinf'><a id='menu_inf' href='listacompra.php'><span class='material-symbols-outlined'>receipt_long</span>LISTA</a></li>
             </ul>
                 </div>";
        }*/

        public static string Footer()
        {
            return @"
                <footer>
                    <img width=125px id='logo_footer' src='images/logotipo.png' alt='Logo'><p>Criado por: equipe Pexinxa</p>
                    
                    <div class='social'>
                        <a id='icon_media' href='#'><img src='https://cdn2.iconfinder.com/data/icons/social-networks-18/100/Instagram_logo-256.png' alt='Instagram'></a>
                        <a id='icon_media' href='#'><img src='https://cdn0.iconfinder.com/data/icons/brands-outlined-3/194/facebook-social-network-brand-logo-256.png' alt='Facebook'></a>
                        <a id='icon_media' href='#'><img src='https://cdn4.iconfinder.com/data/icons/social-media-black-white-2/1227/X-256.png' alt='Twitter/ X'></a>
                    </div>
                </footer>";
        }

        // Outras funções podem ser adicionadas aqui

        public static string Produtos(string nomeProduto, string mercado, decimal preco, string img, string imgMercado)
        {
            return $@"
            <div class='produtos' data-name='{nomeProduto}' data-market='{mercado}' data-price='{preco}' id='prod'>
               <img class='img_produto' src="".$img."">
                        
                        <p class='mercado'> <img class='img_mercado' src="".$img_mercado."">"".$mercado."" </p>

                        <p class='desc_prod'>"".$nome_produto.""</p>
                        <p class='preco'>R$ "".$preco.""<span class='material-symbols-outlined'>
                        add_notes
                        </span></p>
            </div>";
        }

        // Outras funções podem ser adicionadas aqui

        public static string ModalCadastro()
        {
            return @"
                <div class='modal fade' id='staticBackdrop2' tabindex='-1' aria-labelledby='exampleModalLabel2' aria-hidden='true'>
                <div class='modal-dialog d-flex justify-content-center'>
                <div class='modal-content w-75'>
                <div class='modal-header'>
                    <img src='/images/logo.png' alt='logozin' class='logo' style='height: 60px; width: 60px; margin-right: 20px;'>
                    <h5 style='background-image: linear-gradient(to bottom, #EC5714,#FA9D51); /*cria gradiente na font*/
          color: black;
          background-clip: text;
          -webkit-background-clip: text;
          -webkit-text-fill-color: transparent;
          font-weight: bold;'
          class='modal-title' id='exampleModalLabel2'>Registre-se</h5>
                    <button type='button' data-mdb-button-init data-mdb-ripple-init class='btn-close' data-bs-dismiss='modal'
                        aria-label='Close'></button>
             </div>
                    <div class='modal-body p-4'>
                        <form>
                        <!-- Name input -->
                    <div data-mdb-input-init class='form-outline mb-4' style='background-color: rgba(221, 219, 217, 1); border-radius: 5px;'>
                    <input type='text' id='name2' class='form-control' />
                    <label class='form-label' for='name2' style='color: black;'>Nome</label>
            </div>

                    <div data-mdb-input-init class='form-outline mb-4' style='background-color: rgba(221, 219, 217, 1); border-radius: 5px;'>
                        <input type='text' id='name2' class='form-control' />
                        <label class='form-label' for='name2' style='color: black;'>Sobrenome</label>
            </div>

                <!-- Email input -->
                <div data-mdb-input-init class='form-outline mb-4' style='background-color: rgba(221, 219, 217, 1); border-radius: 5px;'>
                    <input type='email' id='email2' class='form-control' />
                    <label class='form-label' for='email2' style='color: black;'>E-mail</label>
                </div>

                <!-- password input -->
                <div data-mdb-input-init class='form-outline mb-4' style='background-color: rgba(221, 219, 217, 1); border-radius: 5px;'>
                    <input type='password' id='password2' class='form-control' />
                    <label class='form-label' for='password2' style='color: black;'>Senha</label>
                </div>

                <!-- cpf input -->
                <div data-mdb-input-init class='form-outline mb-4' style='background-color: rgba(221, 219, 217, 1); border-radius: 5px;'>
                    <input type='number' id='cpf' class='form-control' />
                    <label class='form-label' for='cpf' style='color: black;'>CPF</label>
                </div>

                <div data-mdb-input-init class='form-outline mb-4' style='background-color: rgba(221, 219, 217, 1); border-radius: 5px;'>
                    <input type='number' id='cnpj' class='form-control' />
                    <label class='form-label' for='cnpj' style='color: black;'>CNPJ</label>
                </div>

                <!-- Submit button -->
                <button type='submit' data-mdb-button-init data-mdb-ripple-init class='btn btn-primary btn-block' style='background-color: #EC5714; color: black;'>Registrar</button>
                        </form>
                        </div>
                    </div>
                    </div>
                </div>
                <!-- Modal -->

                <script type='text/javascript' src='https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/7.3.1/mdb.umd.min.js'></script>";

        }

        public static string ModalLogin()
        {
            return @"
            < div class='modal fade' id='exampleModal' tabindex='-1' aria-labelledby='exampleModalLabel' aria-hidden='true'>
                 aria-hidden='true'>
                <div class='modal-dialog' role='document'>
                    <div class='modal-content rounded-4 shadow'>
                        <div class='modal-header p-5 pb-4 border-bottom-0'>
                            <img src='images/logo.png' alt='logozin' class='logo' style='height: 60px; width: 60px; margin-right: 20px;'>
                            <h1 class='fw-bold mb-0 fs-2'>Faça seu Login</h1>
                            <button type='button' class='btn-close' data-bs-dismiss='modal' aria-label='Close'></button>
                        </div>
    
                        <div class='modal-body p-5 pt-0'>
                            <form class=''>
                                <div class='form-floating mb-3'>
                                    <input type='email' class='form-control rounded-3' id='floatingInput'
                                        placeholder='name@example.com' style='background-color: rgba(128, 128, 128, 0.368);'>
                                    <label for='floatingInput'>E-mail</label>
                                </div>
                                <div class='form-floating mb-3'>
                                    <input type='password' class='form-control rounded-3' id='floatingPassword'
                                        placeholder='Password' style='background-color: rgba(128, 128, 128, 0.368);'>
                                    <label for='floatingPassword'>Senha</label>
                                </div>
                                <button class='btnEntrar' type='submit' style='width: 100%; background-color: rgb(255, 128, 0); border: 0; border-radius: 5px; height: 40px'>Entrar</button>
                                <small class='text-body-secondary'></small>
                                <hr class='my-4'>
                                <h2 class='fs-5 fw-bold mb-3'>Quero acessar com as minhas redes sociais</h2>
                                <button class='w-100 py-2 mb-2 btn btn-outline-secondary rounded-3' type='submit'>
                                    <svg class='bi me-1' width='16' height='16'>
                                        <use xlink:href='#twitter' />
                                    </svg>Fatec
                                </button>
                                <button class='w-100 py-2 mb-2 btn btn-outline-primary rounded-3' type='submit'>
                                    <svg class='bi me-1' width='16' height='16'>
                                        <use xlink:href='#facebook' />
                                    </svg>
                                    Facebook
                                </button>
                                <button class='w-100 py-2 mb-2 btn btn-outline-secondary rounded-3' type='submit'>
                                    <svg class='bi me-1' width='16' height='16'>
                                        <use xlink:href='#github' />
                                    </svg>
                                    GitHub
                            </button>
                        </form>
                    </div>
                </div>
            </div>
            </div>";
        }
    }

}
