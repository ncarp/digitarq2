--=====================================================================================
--=== CREATE FULL TEXT INDEX ==========================================================
--=====================================================================================
--/*
CREATE FULLTEXT CATALOG [Catalog]

CREATE FULLTEXT INDEX ON Components
(Abstract, AltFormAvail, BiogHist, CustodHist, GenreForm, GeogName, Note, 
OriginalsLoc, OriginationAuthor, OriginationAuthoraddress, OriginationDestination,
OriginationDestinationAddress, OriginationNotary, OriginationScrivener, PhysLoc,
ScopeContent, UnitTitle)
KEY INDEX PK_Components
ON [Catalog]
--*/
