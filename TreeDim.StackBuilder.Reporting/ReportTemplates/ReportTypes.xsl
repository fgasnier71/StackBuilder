<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:param name="lang"/><!-- param set in command line -->
  <xsl:variable name="loc" select="document(concat( $lang, '.xml'), .)/strings"/>
  <xsl:output method="html" indent="yes"/>
</xsl:stylesheet>
