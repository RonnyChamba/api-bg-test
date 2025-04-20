DROP DATABASE IF EXISTSPRUEBA_INTEGRITY_BG;

CREATE DATABASE PRUEBA_INTEGRITY_BG;


-- registrar formas de pago
INSERT INTO [PRUEBA_INTEGRITY_BG].[dbo].[pay_forms] ([Description])
VALUES 
('Efectivo'),
('Cheque'),
('Transferencia Bancaria'),
('Crédito');


-- registrar secuencial inicial
INSERT INTO [PRUEBA_INTEGRITY_BG].[dbo].[InvoiceSequences] ( [LastNumber])
VALUES (0);



-- template reporte pdf
INSERT INTO [PRUEBA_INTEGRITY_BG].[dbo].[Templates] ( [Id], [Mnemonic], [Html])
VALUES
('1', 'TEMPLATE_FACTURA', '<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Factura</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
            color: #333;
        }

        .container {
            width: 100%;
            max-width: 800px;
            margin: 0 auto;
            border: 1px solid #ddd;
            padding: 20px;
        }

        .header {
            width: 100%;
            margin-bottom: 20px;
        }

        .header table {
            width: 100%;
            border-collapse: collapse;
        }

        .header td {
            vertical-align: top;
            padding: 5px;
        }

        .logo {
            width: 150px;
        }

        .company-info {
            text-align: center;
        }

        .invoice-number {
            text-align: right;
            font-weight: bold;
            font-size: 16px;
        }

        .client-info {
            margin-bottom: 20px;
        }

        .section-header {
            background-color: #2c3e50;
            color: white;
            padding: 8px;
            margin-bottom: 10px;
            font-weight: bold;
        }

        .client-details {
            padding-left: 10px;
        }

        .invoice-meta {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        .invoice-meta th {
            background-color: #2c3e50;
            color: white;
            text-align: left;
            padding: 8px;
        }

        .invoice-meta td {
            padding: 8px;
            border: 1px solid #ddd;
        }

        .products-table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        .products-table th {
            background-color: #2c3e50;
            color: white;
            text-align: left;
            padding: 8px;
        }

        .products-table td {
            padding: 8px;
            border: 1px solid #ddd;
        }

        .products-table tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .text-right {
            text-align: right;
        }

        .totals {
            width: 100%;
        }

        .totals td {
            text-align: right;
            padding: 5px;
        }

        .thank-you {
            text-align: center;
            margin-top: 30px;
            font-weight: bold;
        }
    </style>
</head>

<body>
    <div class="container">
        <!-- Header Section -->
        <div class="header">
            <table>
                <tr>
                    <td width="25%">
                        <div class="logo">
                            <img src="/placeholder.svg?height=80&width=150" alt="Transportes">
                          
                        </div>
                    </td>
                    <td width="50%">
                        <div class="company-info">
                            <div style="font-weight: bold; font-size: 16px;">[KEY_COMPANY_NAME]</div>
                            <div>[KEY_COMPANY_ADDRESS]</div>
                        </div>
                    </td>
                    <td width="25%">
                        <div class="invoice-number">
                            FACTURA Nº [KEY_INVOICE_NUMBER]
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <!-- Client Information -->
        <div class="client-info">
            <div class="section-header">FACTURAR A</div>
            <div class="client-details">
                <div>[KEY_FULLNAME_CUSTOMER]</div>
                <!-- <div>Artigas 19</div> -->
                <div>Teléfono: [KEY_TLF_CUSTOMER]</div>
                <div>Email: [KEY_EMAIL_CUSTOMER]</div>
            </div>
        </div>

        <!-- Invoice Meta Information -->
        <table class="invoice-meta">
            <tr>
                <th width="50%">VENDEDOR</th>
                <th width="50%">FECHA</th>
            </tr>
            <tr>
                <td>[KEY_FULLNAME_USER]</td>
                <td>[KEY_DATE_CREATE]</td>
            </tr>
        </table>

        <!-- Products Table -->
        <table class="products-table">

            <thead>
                <tr>
                    <th width="10%">CANT.</th>
                    <th width="50%">DESCRIPCION</th>
                    <th width="20%">PRECIO UNIT.</th>
                    <th width="20%">PRECIO TOTAL</th>
                </tr>
            </thead>

            <tbody>
                [KEY_DETAILS]
            </tbody>

        </table>

        <!-- Totals -->
        <table class="totals">
            <tr>
                <td width="80%">SUBTOTAL $</td>
                <td width="20%">[KEY_SUBTOTAL]</td>
            </tr>
            <tr>
                <td>IVA [KEY_PORCENTAJE_IVA]% $</td>
                <td>[KEY_VALOR_IVA]</td>
            </tr>
            <tr>
                <td><strong>TOTAL $</strong></td>
                <td><strong>[KEY_TOTAL]</strong></td>
            </tr>
        </table>

          <!-- Formas de Pago -->
          <div class="section-header" style="margin-top: 20px;">FORMAS DE PAGO</div>
          <table class="products-table" style="margin-top: 10px;">

            <thead>
                <tr>
                    <th width="70%">DESCRIPCIÓN</th>
                    <th width="30%">MONTO</th>
                </tr>
            </thead>

            <tbody>
                [KEY_PAY_FORMS]
            </tbody>
          </table>
          

        <!-- Thank You Message -->
        <div class="thank-you">
            Gracias por su compra!
        </div>
    </div>
</body>

</html>');
