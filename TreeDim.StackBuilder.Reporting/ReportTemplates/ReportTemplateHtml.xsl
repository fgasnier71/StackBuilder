<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="ReportTypes.xsl"/>
  <xsl:output method="html"/>
  <xsl:template match="report">
    <html>
      <head>
        <title>
          <xsl:value-of select="name"></xsl:value-of>
          <xsl:value-of select="$loc/str[@name='report']"/>
        </title>
        <style type="text/css">
          .style1
          {
          color:blue;
          }
          .style2
          {
          width: 50mm;
          color:black;
          font-family:Arial;
          font-size:10px;
          }
          .style3
          {
          color:black;
          font-family:Arial;
          font-size:10px;
          }
          body
          {
          font-family:Arial;
          font-size:11px;
          margin: 5%;
          width: 90%;
          padding: 0;
          }
          h1
          {
          color:black;
          font-size:20px;
          font-family:Arial;
          width:200mm
          }
          h2
          {
          color:red;
          font-size:16px;
          font-family:Arial;
          }
          h3
          {
          color:blue;
          font-size:12px;
          font-family:Arial;
          }
          table
          {
          border:solid grey 1px;
          width:200mm;
          border-spacing: 0px;
          cell-spacing: 0px;
          }
          td
          {
          padding: 0px;
          }
        </style>
      </head>
      <!-- HEADER -->
      <body>
        <table class="style1" cellpadding="4">
          <tr>
            <td class="style2" colspan="1">
              <b>
                <xsl:value-of select="$loc/str[@name='Document']"/>
              </b>
            </td>
            <td class="style3" colspan="2">
              <xsl:value-of select="name"/>
            </td>
            <xsl:if test="companyLogo">
              <td colspan="1" align="middle">
                <xsl:apply-templates select="companyLogo"/>
              </td>
            </xsl:if>
          </tr>
          <tr>
            <td class="style2" colspan="1">
              <b>
                <xsl:value-of select="$loc/str[@name='Description']"/>
              </b>
            </td>
            <td class="style3" colspan="2">
              <xsl:value-of select="description"/>
            </td>
            <td class="style2" colspan="1"/>
          </tr>
          <tr>
            <td class="style2" colspan="1">
              <b>
                <xsl:value-of select="$loc/str[@name='Date']"/>
              </b>
            </td>
            <td class="style3" colspan="1">
              <xsl:value-of select="dateOfCreation"/>
            </td>
            <td class="style2" colspan="1">
              <b>
                <xsl:value-of select="$loc/str[@name='Author']"/>
              </b>
            </td>
            <td class="style3" colspan="1">
              <xsl:value-of select="author"></xsl:value-of>
            </td>
          </tr>
        </table>
        <xsl:apply-templates select="analysis"/>
      </body>
    </html>
  </xsl:template>
  <!--#### ANALYSIS ####-->
  <xsl:template match="analysis">
    <h2>
      <xsl:value-of select="$loc/str[@name='Analysis']"/>: <xsl:value-of select="name"/>
    </h2>
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Description']"/>
          </b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"/>
        </td>
      </tr>
    </table>
    <xsl:apply-templates select="cylinder"/>
    <xsl:apply-templates select="box"/>
    <xsl:apply-templates select="bundle"/>
    <xsl:apply-templates select="pack"/>
    <xsl:apply-templates select="caseWithInnerDims"/>
    <xsl:apply-templates select="pallet"/>
    <xsl:apply-templates select="truck"/>
    <xsl:apply-templates select="interlayer"/>
    <xsl:apply-templates select="palletCorner"/>
    <xsl:apply-templates select="palletCap"/>
    <xsl:apply-templates select="palletFilm"/>
    <xsl:apply-templates select="constraintSet"/>
    <xsl:apply-templates select="solution"/>
  </xsl:template>
  <!--#### ECTANALYSIS ####-->
  <xsl:template match="ectAnalysis">
    <h2>
      <xsl:value-of select="$loc/str[@name='Box Compression Test analysis']"/>
    </h2>
    <xsl:apply-templates select="cardboard"></xsl:apply-templates>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Case type']"/>
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Printed surface']"/>
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Mc Kee Formula']"/>
          </b>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <xsl:value-of select="caseType"></xsl:value-of>
        </td>
        <td class="style3">
          <xsl:value-of select="printedSurface"></xsl:value-of>
        </td>
        <td class="style3">
          <xsl:value-of select="mcKeeFormulaMode"></xsl:value-of>
        </td>
      </tr>
    </table>
    <xsl:apply-templates select="bct_static"></xsl:apply-templates>
    <xsl:apply-templates select="bct_dynamic"></xsl:apply-templates>
  </xsl:template>
  <!--#### CONSTRAINT SET ####-->
  <xsl:template match="constraintSet">
    <h3>
      <xsl:value-of select="$loc/str[@name='Constraint set']"/>
    </h3>
    <table class="style1">
      <xsl:if test="overhangX">
        <tr>
          <td class="style2">
            <b>
              <xsl:value-of select="$loc/str[@name='Overhang Length / Width']"/> (<xsl:value-of select="overhangX/unit"></xsl:value-of>)
            </b>
          </td>
          <td class="style3">
            <xsl:value-of select="overhangX/value"/> / <xsl:value-of select="overhangY/value"/>
          </td>
        </tr>
      </xsl:if>
      <xsl:if test="maximumHeight">
        <tr>
          <td class="style2">
            <b>
              <xsl:value-of select="$loc/str[@name='Maximum pallet height']"/> (<xsl:value-of select="maximumHeight/unit"/>)
            </b>
          </td>
          <td class="style3" colspan="3">
            <xsl:value-of select="maximumHeight/value"/>
          </td>
        </tr>
      </xsl:if>
      <xsl:if test="maximumWeight">
        <tr>
          <td class="style2">
            <b>
              <xsl:value-of select="$loc/str[@name='Maximum weight']"/> (<xsl:value-of select="maximumWeight/unit"/>)
            </b>
          </td>
          <td class="style3" colspan="3">
            <xsl:value-of select="maximumWeight/value"/>
          </td>
        </tr>
      </xsl:if>
      <xsl:if test="maximumNumber">
        <tr>
          <td class="style2">
            <b>
              <xsl:value-of select="$loc/str[@name='Maximum number']"/>
            </b>
          </td>
          <td class="style3" colspan="3">
            <xsl:value-of select="maximumNumber"/>
          </td>
        </tr>
      </xsl:if>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Allowed ortho axes']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowedOrthoAxis"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### SOLUTION ####-->
  <xsl:template match="solution">
    <h3>
      <xsl:value-of select="$loc/str[@name='Solution']"/>
    </h3>
    <table class="style1">
      <xsl:apply-templates select="item"/>
      <xsl:if test="netWeight">
        <tr>
          <td class="style2" colspan="1">
            <b>
              <xsl:value-of select="$loc/str[@name='Net weight']"/> (<xsl:value-of select="netWeight/unit"/>)
            </b>
          </td>
          <td class="style3" colspan="3">
            <xsl:value-of select="netWeight/value"/>
          </td>
        </tr>
      </xsl:if>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Load weight']"/> (<xsl:value-of select="loadWeight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="loadWeight/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Weight']"/> (<xsl:value-of select="totalWeight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="totalWeight/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Volume efficiency']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="efficiencyVolume"/>
        </td>
      </tr>
      <tr>
        <td align="middle" colspan="1">
          <xsl:apply-templates select="view_solution_front"/>
        </td>
        <td align="middle" colspan="1">
          <xsl:apply-templates select="view_solution_left"/>
        </td>
        <td align="middle" colspan="1">
          <xsl:apply-templates select="view_solution_right"/>
        </td>
        <td align="middle" colspan="1">
          <xsl:apply-templates select="view_solution_back"/>
        </td>
      </tr>
      <tr>
        <td colspan="4" align="middle">
          <xsl:apply-templates select="view_solution_iso"/>
        </td>
      </tr>
    </table>
    <xsl:apply-templates select="layers"/>

  </xsl:template>
  <!--### ITEM ####-->
  <xsl:template match="item">
    <tr>
      <td class="style2" colspan="1">
        <b>
          <xsl:value-of select="name"/>
        </b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="value"/>
      </td>
    </tr>
  </xsl:template>
  <!--#### COMPANYLOGO ####-->
  <xsl:template match="companyLogo" >
    <img align="middle">
      <xsl:attribute name="src">
        <xsl:value-of select="imagePath"/>
      </xsl:attribute>
      <xsl:attribute name="width"/>
      <xsl:attribute name="height"/>
    </img>
  </xsl:template>
  <!--#### view_layer ####-->
  <xsl:template match ="view_layer">
    <img align="middle">
      <xsl:attribute name="src">
        <xsl:value-of select="imagePath"/>
      </xsl:attribute>
      <xsl:attribute name="width">
        <xsl:value-of select="width"/>
      </xsl:attribute>
      <xsl:attribute name="height">
        <xsl:value-of select="height"/>
      </xsl:attribute>
    </img>
  </xsl:template>
  <!--#### IMAGEGENERIC ####-->
  <xsl:template match="imageThumbSize">
    <img align="middle">
      <xsl:attribute name="src">
        <xsl:value-of select="imagePath"/>
      </xsl:attribute>
      <xsl:attribute name="width">
        <xsl:value-of select="width"/>
      </xsl:attribute>
      <xsl:attribute name="height">
        <xsl:value-of select="height"/>
      </xsl:attribute>
    </img>
  </xsl:template>
  <!--#### VIEW_SOLUTION_FRONT-->
  <xsl:template match="view_solution_front">
    <img width="150" height="150" align="middle">
      <xsl:attribute name="src">
        <xsl:value-of select="imagePath"/>
      </xsl:attribute>
    </img>
  </xsl:template>
  <!--#### VIEW_SOLUTION_LEFT-->
  <xsl:template match="view_solution_left">
    <img width="150" height="150" align="middle">
      <xsl:attribute name="src">
        <xsl:value-of select="imagePath"/>
      </xsl:attribute>
    </img>
  </xsl:template>
  <!--#### VIEW_SOLUTION_RIGHT-->
  <xsl:template match="view_solution_right">
    <img width="150" height="150" align="middle">
      <xsl:attribute name="src">
        <xsl:value-of select="imagePath"/>
      </xsl:attribute>
    </img>
  </xsl:template>
  <!--#### VIEW_SOLUTION_BACK-->
  <xsl:template match="view_solution_back">
    <img width="150" height="150" align="middle">
      <xsl:attribute name="src">
        <xsl:value-of select="imagePath"/>
      </xsl:attribute>
    </img>
  </xsl:template>
  <!--#### VIEW_SOLUTION_ISO-->
  <xsl:template match="view_solution_iso">
    <img width="450" height="450" align="middle">
      <xsl:attribute name="src">
        <xsl:value-of select="imagePath"/>
      </xsl:attribute>
    </img>
  </xsl:template>
  <!--#### LAYERS ####-->
  <xsl:template match="layers">
    <h3>
      <xsl:value-of select="$loc/str[@name='Layer(s)']"/>
    </h3>
    <xsl:apply-templates select="layer"/>

  </xsl:template>
  <!--#### LAYER ####-->
  <xsl:template match="layer">
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Layer(s)']"/>
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="layerIndexes"/>
        </td>
        <td rowspan="5" align="middle">
          <xsl:apply-templates select="imageThumb"/>
        </td>
      </tr>
      <xsl:apply-templates select="item"/>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Dimensions']"/> (<xsl:value-of select="layerLength/unit"/> x <xsl:value-of select="layerWidth/unit"/> x <xsl:value-of select="layerHeight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="layerLength/value"/> x <xsl:value-of select="layerWidth/value"/> x <xsl:value-of select="layerHeight/value"/>
        </td>

      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Weight']"/> (<xsl:value-of select="layerWeight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="layerWeight/value"/>
        </td>
      </tr>
      <xsl:if test="netWeight">
        <tr>
          <td class="style2" colspan="1">
            <b>
              <xsl:value-of select="$loc/str[@name='Net weight']"/> (<xsl:value-of select="layerNetWeight/unit"/>)
            </b>
          </td>
          <td class="style3" colspan="1">
            <xsl:value-of select="layerNetWeight/value"/>
          </td>
        </tr>
      </xsl:if>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Spaces']"/> (<xsl:value-of select="layerSpaces/unit"/>)
          </b>
        </td>
        <td class="style3" colspace="1">
          <xsl:value-of select="layerSpaces/value"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--LAYER PACK SOLUTION-->
  <xsl:template match="layerPack">
    <tr>
      <td class="style3" colspan="1">
        <xsl:value-of select="layerPackCount"/>/<xsl:value-of select="layerCSUCount"/>
      </td>
      <td class="style3" colspan="1">
        <xsl:value-of select="layerWeight/value"/> / <xsl:value-of select="layerNetWeight/value"/>
      </td>
      <td class="style3" colspan="1">
        <xsl:value-of select="layerLength/value"/>*<xsl:value-of select="layerWidth/value"/>*<xsl:value-of select="layerHeight/value"/>
      </td>
      <td class="style3" colspan="1">
        <xsl:value-of select="maximumSpace/value"/>
      </td>
      <td class="style3" colspan="1">
        <xsl:value-of select="layerIndexes"/>
      </td>
      <td class="style3" colspan="4">
        <xsl:element name="img">
          <xsl:attribute name="src">
            <xsl:value-of select="imagePackLayer"/>
          </xsl:attribute>
        </xsl:element>
      </td>
    </tr>
  </xsl:template>
  <!--CARDBOARD-->
  <xsl:template match="cardboard">
    <h3>
      <xsl:value-of select="$loc/str[@name='Carton']"/>
    </h3>
    <b>
      <xsl:value-of select="$loc/str[@name='Cardboard']"/>
    </b>
    <table border="1" cellpadding="5">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Name']"/>
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Thickness']"/> (<xsl:value-of select="thickness/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='ECT']"/> (<xsl:value-of select="ect/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='StiffnessX']"/> (<xsl:value-of select="stiffnessX/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='StiffnessY']"/> (<xsl:value-of select="stiffnessY/unit"></xsl:value-of>)
          </b>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="thickness/value"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="ect/value"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="stiffnessX/value"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="stiffnessY/value"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BCT_STATIC-->
  <xsl:template match="bct_static">
    <table border="1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Static BCP']"/>
          </b>
        </td>
        <td class="style3">
          <xsl:text></xsl:text>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BCT_DYNAMIC-->
  <xsl:template match="bct_dynamic">
    <b>
      <xsl:value-of select="$loc/str[@name='Dynamic BCP']"/>
    </b>
    <table border="1" cellpadding="7">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Storage']"/>
          </b>
        </td>
        <td class="style2">
          <b>0-45 %</b>
        </td>
        <td class="style2">
          <b>46-55 %</b>
        </td>
        <td class="style2">
          <b>56-65 %</b>
        </td>
        <td class="style2">
          <b>66-75 %</b>
        </td>
        <td class="style2">
          <b>76-85 %</b>
        </td>
        <td class="style2">
          <b>86-100 %</b>
        </td>
      </tr>
      <xsl:apply-templates select="bct_dynamic_storage"></xsl:apply-templates>
    </table>
  </xsl:template>
  <!--BCT_DYNAMIC_STORAGE-->
  <xsl:template match="bct_dynamic_storage">
    <tr>
      <td class="style2">
        <b>
          <xsl:value-of select="duration"></xsl:value-of>
        </b>
      </td>
      <xsl:apply-templates select="humidity_0_45"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_46_55"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_56_65"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_66_75"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_76_85"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_86_100"></xsl:apply-templates>
    </tr>
  </xsl:template>
  <!--humidity_0_45-->
  <xsl:template match="humidity_0_45">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_46_55-->
  <xsl:template match="humidity_46_55">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_56_65-->
  <xsl:template match="humidity_56_65">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_66_75-->
  <xsl:template match="humidity_66_75">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_76_85-->
  <xsl:template match="humidity_76_85">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_76_85-->
  <xsl:template match="humidity_86_100">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>