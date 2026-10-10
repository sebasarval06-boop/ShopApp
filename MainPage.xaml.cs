using ShopApp.DataAcces;

namespace ShopApp
{
    public partial class MainPage : ContentPage
    {
        private readonly ShopDbContext _context;

        public MainPage()
        {
            InitializeComponent();
            _context = new ShopDbContext();
            CargarTodosLosProductos();
        }

        private void CargarTodosLosProductos()
        {
            LblResultadoTitulo.Text = "Todos los productos:";
            LblInfoEspecial.IsVisible = false;
            CvProductos.ItemsSource = _context.Products.ToList();
        }

        private void OnGetAllProductsClicked(object sender, EventArgs e)
        {
            CargarTodosLosProductos();
        }

        // 1. Productos de la categoría "Computadoras"
        private void OnGetComputersClicked(object sender, EventArgs e)
        {
            LblResultadoTitulo.Text = "Productos en categoría 'Computadoras':";
            LblInfoEspecial.IsVisible = false;

            var productosComputadoras = _context.Products
                .Where(p => p.CategoryId == 2)
                .ToList();

            CvProductos.ItemsSource = productosComputadoras;
        }

        // 2. Productos con precio > 1000
        private void OnGetExpensiveProductsClicked(object sender, EventArgs e)
        {
            LblResultadoTitulo.Text = "Productos con Precio > $1000:";
            LblInfoEspecial.IsVisible = false;

            var productosCaros = _context.Products
                .Where(p => p.Precio > 1000)
                .OrderByDescending(p => p.Precio)
                .ToList();

            CvProductos.ItemsSource = productosCaros;
        }

        // 3. Categoría del producto más caro
        private void OnGetCategoryMostExpensiveClicked(object sender, EventArgs e)
        {
            LblResultadoTitulo.Text = "Producto más caro y su categoría:";

            var productoMasCaro = _context.Products
                .OrderByDescending(p => p.Precio)
                .FirstOrDefault();

            if (productoMasCaro != null)
            {
                var categoria = _context.Categories
                    .FirstOrDefault(c => c.Id == productoMasCaro.CategoryId);

                string nombreCategoria = categoria != null ? categoria.Nombre : "Desconocida";

                LblInfoEspecial.Text = $"Categoría: '{nombreCategoria}' | Producto: {productoMasCaro.Nombre} (${productoMasCaro.Precio})";
                LblInfoEspecial.IsVisible = true;

                CvProductos.ItemsSource = new List<Product> { productoMasCaro };
            }
        }
    }
}